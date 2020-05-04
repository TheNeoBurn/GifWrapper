using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace BjSTools.IO {
    public abstract class GifPart {
        protected List<GifPart> _parts = new List<GifPart>();

        public virtual int Length { get { return _parts.Sum(p => p.Length); } }

        public virtual byte[] GetData() {
            byte[] result;
            using (MemoryStream ms = new MemoryStream()) {
                byte[] buffer;
                foreach (GifPart part in _parts) {
                    buffer = part.GetData();
                    if (buffer != null && buffer.Length > 0)
                        ms.Write(buffer, 0, buffer.Length);
                }
                result = ms.ToArray();
            }
            return result;
        }

        public abstract GifPart CreateCopy();

        #region General Part definitions

        public abstract class GifPartData : GifPart {
            protected byte[] _data = null;

            public override int Length { get { return _data == null ? 0 : _data.Length; } }

            public GifPartData() { }
            public GifPartData(ref byte[] data, ref int index, int length) {
                _data = new byte[length];
                Array.Copy(data, index, _data, 0, length);
                index += length;
            }

            public override byte[] GetData() {
                return _data;
            }

            protected ushort GetUInt16(int index) {
                return Convert.ToUInt16(_data[index] | (_data[index + 1] << 8));
            }
            protected void SetUInt16(int index, ushort value) {
                _data[index] = Convert.ToByte(value & 0xFF);
                _data[index + 1] = Convert.ToByte((value & 0xFF00) >> 8);
            }

            protected string GetString(int index, int len) {
                return Encoding.ASCII.GetString(_data, index, len);
            }
            protected void SetString(int index, int len, string value) {
                byte[] buffer = Encoding.ASCII.GetBytes(value);
                if (buffer.Length != len) throw new Exception("The strings length must be " + len.ToString() + "!");
                for (int i = 0; i < len; i++) { _data[index + i] = buffer[i]; }
            }

        }

        public abstract class GifPartList : GifPart, IList<GifPart> {
            public GifPart this[int index] { get { return _parts[index]; } set { _parts[index] = value; } }
            public int Count { get { return _parts.Count; } }
            public bool IsReadOnly { get { return false; } }
            public void Add(GifPart item) { _parts.Add(item); }
            public void Clear() { _parts.Clear(); }
            public bool Contains(GifPart item) { return _parts.Contains(item); }
            public void CopyTo(GifPart[] array, int arrayIndex) { _parts.CopyTo(array, arrayIndex); }
            public IEnumerator<GifPart> GetEnumerator() { return _parts.GetEnumerator(); }
            public int IndexOf(GifPart item) { return _parts.IndexOf(item); }
            public void Insert(int index, GifPart item) { _parts.Insert(index, item); }
            public bool Remove(GifPart item) { return _parts.Remove(item); }
            public void RemoveAt(int index) { _parts.RemoveAt(index); }
            IEnumerator IEnumerable.GetEnumerator() { return (_parts as IEnumerable).GetEnumerator(); }
        }

        public interface IGifPartContent {
            byte[] Content { get; set; }
        }

        public class GifParserException : Exception {
            public int Position { get; private set; }

            public GifParserException(int index, string msg) : base(msg) {
                this.Position = index;
            }
            public GifParserException(int index, string msg, Exception innerException) : base(msg, innerException) {
                this.Position = index;
            }
        }

        protected class ZeroPart : GifPart {
            public override int Length { get { return 0; } }

            public ZeroPart() { }

            public override byte[] GetData() { return new byte[0]; }

            public override GifPart CreateCopy() {
                return new ZeroPart();
            }
        }

        protected class ColorTablePart : GifPartData, IList<Color> {
            private static readonly int[] VALID_COUNTS = new[] { 0x0002, 0x0004, 0x0008, 0x0010, 0x0020, 0x0040, 0x0080, 0x0100 };

            public ColorTablePart(ref byte[] data, ref int index, int colorCount) : base(ref data, ref index, 3 * colorCount) {
                this.Count = colorCount;
            }
            public ColorTablePart(List<Color> colors) {
                // Ensure correct color count
                if (colors.Count > 0x0100) throw new Exception("Too many color for a GIF color table!");
                while (!VALID_COUNTS.Contains(colors.Count)) {
                    colors.Add(Color.Black);
                }

                // Create data
                _data = new byte[3 * colors.Count];
                int index = -1;
                foreach (Color c in colors) {
                    _data[++index] = c.R;
                    _data[++index] = c.G;
                    _data[++index] = c.B;
                }

                this.Count = colors.Count;
            }
            private ColorTablePart(int count, byte[] data) {
                _data = data;
                this.Count = count;
            }

            public override GifPart CreateCopy() {
                byte[] buffer = new byte[_data.Length];
                Array.Copy(_data, buffer, _data.Length);
                return new ColorTablePart(this.Count, buffer);
            }

            public int Count { get; private set; }
            public bool IsReadOnly { get { return true; } }

            public Color this[int index] {
                get {
                    if (index < 0 || index >= Count)
                        throw new IndexOutOfRangeException("Index is not within the color count range!");
                    int offset = 3 * index;
                    return Color.FromArgb(_data[offset + 0], _data[offset + 1], _data[offset + 2]);
                }
                set {
                    if (index < 0 || index >= Count)
                        throw new IndexOutOfRangeException("Index is not within the color count range!");
                    int offset = 3 * index;
                    _data[offset + 0] = value.R;
                    _data[offset + 1] = value.G;
                    _data[offset + 2] = value.B;
                }
            }

            private class ColorTableEnumerator : IEnumerator<Color> {
                private ColorTablePart _table;
                private int _index;

                public Color Current { get { return _table[_index]; } }
                object IEnumerator.Current { get { return this.Current; } }

                public ColorTableEnumerator(ColorTablePart table) {
                    _table = table;
                    _index = -1;
                }

                public void Dispose() { }
                public bool MoveNext() {
                    _index++;
                    return _index < _table.Count;
                }
                public void Reset() { _index = -1; }
            }

            public IEnumerator<Color> GetEnumerator() { return new ColorTableEnumerator(this); }
            IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

            public void Add(Color item) { throw new Exception("This collection is read-only!"); }
            public void Clear() { throw new Exception("This collection is read-only!"); }
            public bool Contains(Color item) {
                bool result = false;
                for (int i = 0; i < this.Count; i++) {
                    if (this[i].Equals(item)) {
                        result = true;
                        break;
                    }
                }
                return result;
            }
            public void CopyTo(Color[] array, int arrayIndex) {
                for (int i = 0; i < this.Count; i++) {
                    array[arrayIndex + i] = this[i];
                }
            }
            public bool Remove(Color item) { throw new Exception("This collection is read-only!"); }
            public int IndexOf(Color item) {
                int result = -1;
                for (int i = 0; i < this.Count; i++) {
                    if (this[i].Equals(item)) {
                        result = i;
                        break;
                    }
                }
                return result;
            }
            public void Insert(int index, Color item) { throw new Exception("This collection is read-only!"); }
            public void RemoveAt(int index) { throw new Exception("This collection is read-only!"); }
        }

        protected class GifDataSection : GifPart {
            protected class SectionPart : GifPartData {
                public byte[] Data { get { return _data; } }
                public byte DataLength { get { return _data[0]; } }

                public SectionPart(byte[] data) {
                    if (data.Length != data[0] + 1) throw new Exception("Length indicator does not equal the data length!");
                    _data = data;
                }
                public SectionPart() {
                    _data = new byte[] { 0x00 };
                }

                public override GifPart CreateCopy() {
                    byte[] buffer = new byte[_data.Length];
                    Array.Copy(_data, buffer, _data.Length);
                    return new SectionPart(buffer);
                }
            }

            public GifDataSection(ref byte[] data, ref int index) {
                int len;
                while ((len = ((int)data[index]) + 1) != 1) {
                    byte[] buffer = new byte[len];
                    Array.Copy(data, index, buffer, 0, len);
                    _parts.Add(new SectionPart(buffer));
                    index += len; // Move to next length index
                }
                _parts.Add(new SectionPart());
                index++;
            }
            public GifDataSection(byte[] content) {
                this.Content = content;
            }
            private GifDataSection(List<GifPart> parts) {
                _parts = parts;
            }

            /// <summary>Gets or sets the byte content within the data packets</summary>
            public byte[] Content {
                get {
                    byte[] result = null;

                    using (MemoryStream ms = new MemoryStream()) {
                        _parts
                            .Select(p => p as SectionPart).ToList()
                            .ForEach(p => ms.Write(p.Data, 1, p.DataLength));
                        result = ms.ToArray();
                    }

                    return result;
                }
                set {
                    _parts.Clear();
                    int index = 0;
                    byte[] buffer;
                    while (index < value.Length) {
                        int cnt = Math.Min(255, value.Length - index);
                        buffer = new byte[cnt + 1];
                        buffer[0] = Convert.ToByte(cnt);
                        Array.Copy(value, index, buffer, 1, cnt);
                        _parts.Add(new SectionPart(buffer));
                        index += cnt;
                    }
                    _parts.Add(new SectionPart());
                }
            }

            public override GifPart CreateCopy() {
                return new GifDataSection(_parts.Select(p => p.CreateCopy()).ToList());
            }
        }

        #endregion

    }

    #region File part implementations

    /// <summary>GIF header information (may contain a color table)</summary>
    public class GifPartHeader : GifPart {
        private class HeaderPart : GifPartData {
            private static readonly string[] VALID_VERSIONS = new[] { "89a", "87a" };

            public string Identifier {
                get { return GetString(0, 3); }
                set { SetString(0, 3, value); }
            }
            public string Version {
                get { return GetString(3, 3); }
                set { SetString(3, 3, value); }
            }
            public ushort Width {
                get { return GetUInt16(6); }
                set { SetUInt16(6, value); }
            }
            public ushort Height {
                get { return GetUInt16(8); }
                set { SetUInt16(8, value); }
            }
            public bool UseGlobalColorTable {
                get { return (_data[10] & 0x80) != 0; }
                set { _data[10] = Convert.ToByte((_data[10] & 0x7F) | (value ? 0x80 : 0x00)); }
            }
            public byte ColorResolution {
                get { return Convert.ToByte((_data[10] & 0x70) >> 4); }
                set { _data[10] = Convert.ToByte((_data[10] & 0x8F) | ((value & 0x07) << 4)); }
            }
            public bool TableSorted {
                get { return (_data[10] & 0x08) != 0; }
                set { _data[10] = Convert.ToByte((_data[10] & 0xF7) | (value ? 0x04 : 0x00)); }
            }
            public int GlobalColorTableSize {
                get { return 2 << (_data[10] & 0x07); }
                set {
                    byte val = 0;
                    for (int i = 0; i < 7; i++) { if (value > (2 << i)) val++; }
                    _data[10] = Convert.ToByte((_data[10] & 0xF8) | val);
                }
            }
            public byte BackgroundColor {
                get { return _data[11]; }
                set { _data[11] = value; }
            }
            public byte AspectRatio {
                get { return _data[12]; }
                set { _data[12] = value; }
            }

            public HeaderPart(ref byte[] data, ref int index) : base(ref data, ref index, 13) {
                if (!Identifier.Equals("GIF")) throw new GifParserException(index - 13, "Header does not start with 'GIF'!");
                if (!VALID_VERSIONS.Any(v => v.Equals(this.Version))) throw new GifParserException(index - 10, "File version not supported!");
            }
            public HeaderPart() {
                _data = new byte[13];
                this.Identifier = "GIF";
                this.Version = VALID_VERSIONS[0];
            }
            private HeaderPart(byte[] data) {
                _data = data;
            }

            public override GifPart CreateCopy() {
                byte[] buffer = new byte[_data.Length];
                Array.Copy(_data, buffer, _data.Length);
                return new HeaderPart(buffer);
            }
        }

        private HeaderPart Header { get { return _parts[0] as HeaderPart; } }

        /// <summary>The first 3 bytes are always "GIF" as an identifier</summary>
        public string Identifier { get { return Header.Identifier; } set { Header.Identifier = value; } }
        /// <summary>The file version: 89a or 87a</summary>
        public string Version { get { return Header.Version; } set { Header.Version = value; } }
        /// <summary>The width of the image - the first byte is the least significant: "01 00" would be 1 as "00 01" would be 256</summary>
        public ushort Width { get { return Header.Width; } set { Header.Width = value; } }
        /// <summary>The height of the image - the first byte is the least significant again</summary>
        public ushort Height { get { return Header.Height; } set { Header.Height = value; } }
        /// <summary>If set to 1, a global color table is used</summary>
        public bool UseGlobalColorTable { get { return Header.UseGlobalColorTable; } set { Header.UseGlobalColorTable = value; } }
        /// <summary>The number of bits used to describe a pixel</summary>
        public byte ColorResolution { get { return Header.ColorResolution; } set { Header.ColorResolution = value; } }
        /// <summary>If set to 1, the global color table is sorted by ascending occurence in the image data</summary>
        public bool TableSorted { get { return Header.TableSorted; } set { Header.TableSorted = value; } }
        /// <summary>The number of colors in the table (internally calculated with 2^(N+1) - so 001 would stand for 4 colors - thus only values 2, 4, 8, 16, 32, 64, 128 and 256 are allowed!)</summary>
        public int GlobalColorTableSize { get { return Header.GlobalColorTableSize; } set { Header.GlobalColorTableSize = value; } }
        /// <summary>The index of the background color - irrelevant if no global color table is used</summary>
        public byte BackgroundColor { get { return Header.BackgroundColor; } set { Header.BackgroundColor = value; } }
        /// <summary>This is ignored nowadays</summary>
        public byte AspectRatio { get { return Header.AspectRatio; } set { Header.AspectRatio = value; } }

        /// <summary>The Global color table or null if none is present</summary>
        public IList<Color> GlobalColorTable {
            get { return (_parts[1] as ColorTablePart); }
            set {
                if (value == null) {
                    _parts[1] = new ZeroPart();
                    UseGlobalColorTable = false;
                    GlobalColorTableSize = 0;
                } else {
                    ColorTablePart part = new ColorTablePart(value.ToList());
                    UseGlobalColorTable = true;
                    GlobalColorTableSize = part.Count;
                    _parts[1] = part;
                }
            }
        }

        public GifPartHeader(ref byte[] data, ref int index) {
            _parts.Add(new HeaderPart(ref data, ref index));

            if (UseGlobalColorTable) {
                _parts.Add(new ColorTablePart(ref data, ref index, GlobalColorTableSize));
            } else {
                _parts.Add(new ZeroPart());
            }
        }
        public GifPartHeader() {
            _parts.Add(new HeaderPart());
            _parts.Add(new ZeroPart());
        }
        private GifPartHeader(List<GifPart> parts) {
            _parts = parts;
        }

        public override GifPart CreateCopy() {
            return new GifPartHeader(_parts.Select(p => p.CreateCopy()).ToList());
        }
    }

    /// <summary>GIF LWZ image information</summary>
    public class GifPartLwzImage : GifPart {
        private class HeaderPart : GifPartData {
            public byte Identifier {
                get { return _data[0]; }
                set { _data[0] = value; }
            }
            public ushort Left {
                get { return GetUInt16(1); }
                set { SetUInt16(1, value); }
            }
            public ushort Top {
                get { return GetUInt16(3); }
                set { SetUInt16(3, value); }
            }
            public ushort Width {
                get { return GetUInt16(5); }
                set { SetUInt16(5, value); }
            }
            public ushort Height {
                get { return GetUInt16(7); }
                set { SetUInt16(7, value); }
            }
            public bool UseLocalColorTable {
                get { return (_data[9] & 0x80) != 0; }
                set { _data[9] = Convert.ToByte((_data[9] & 0x7F) | (value ? 0x80 : 0x00)); }
            }
            public bool Interlaced {
                get { return (_data[9] & 0x40) != 0; }
                set { _data[9] = Convert.ToByte((_data[9] & 0xBF) | (value ? 0x40 : 0x00)); }
            }
            public bool TableSorted {
                get { return (_data[9] & 0x20) != 0; }
                set { _data[9] = Convert.ToByte((_data[9] & 0xDF) | (value ? 0x20 : 0x00)); }
            }
            public int LocalColorTableSize {
                get { return 2 << (_data[9] & 0x07); }
                set {
                    byte val = 0;
                    for (int i = 0; i < 7; i++) { if (value > (2 << i)) val++; }
                    _data[9] = Convert.ToByte((_data[9] & 0xF8) | val);
                }
            }

            public HeaderPart(ref byte[] data, ref int index) : base(ref data, ref index, 10) { }
            public HeaderPart() {
                _data = new byte[10];
                this.Identifier = 0x2C;
            }
            private HeaderPart(byte[] data) {
                _data = data;
            }

            public override GifPart CreateCopy() {
                byte[] buffer = new byte[_data.Length];
                Array.Copy(_data, buffer, _data.Length);
                return new HeaderPart(buffer);
            }
        }

        private class MinimumCodeSizePart : GifPartData {
            public byte MinimumCodeSize {
                get { return _data[0]; }
                set { _data[0] = value; }
            }

            public MinimumCodeSizePart(ref byte[] data, ref int index) {
                _data = new byte[] { data[index] };
                index++;
            }
            private MinimumCodeSizePart(byte[] data) {
                _data = data;
            }

            public override GifPart CreateCopy() {
                byte[] buffer = new byte[_data.Length];
                Array.Copy(_data, buffer, _data.Length);
                return new MinimumCodeSizePart(buffer);
            }
        }

        public GifWrapper Wrapper { get; set; }

        private HeaderPart Header { get { return _parts[0] as HeaderPart; } }

        /// <summary>The LWZ image part identification 0x2C</summary>
        public byte Identifier { get { return Header.Identifier; } private set { Header.Identifier = value; } }
        /// <summary>The horizontal position of this image in the global image surface - least significant byte first</summary>
        public ushort Left { get { return Header.Left; } set { Header.Left = value; } }
        /// <summary>The vertical position of this image in the global image surface- least significant byte first</summary>
        public ushort Top { get { return Header.Top; } set { Header.Top = value; } }
        /// <summary>The width of this image part - least significant byte first</summary>
        public ushort Width { get { return Header.Width; } set { Header.Width = value; } }
        /// <summary>The height of this image part - least significant byte first</summary>
        public ushort Height { get { return Header.Height; } set { Header.Height = value; } }
        /// <summary>If set to 1, a local color table is used</summary>
        public bool UseLocalColorTable { get { return Header.UseLocalColorTable; } private set { Header.UseLocalColorTable = value; } }
        /// <summary>Only used by the renderer</summary>
        public bool Interlaced { get { return Header.Interlaced; } set { Header.Interlaced = value; } }
        /// <summary>If set to 1, the local color table is sorted by ascending occurence in the image data</summary>
        public bool TableSorted { get { return Header.TableSorted; } set { Header.TableSorted = value; } }
        /// <summary>The number of colors in the table (internally calculated with 2^(N+1) - thus only values 2, 4, 8, 16, 32, 64, 128 and 256 are allowed!)</summary>
        public int LocalColorTableSize { get { return Header.LocalColorTableSize; } private set { Header.LocalColorTableSize = value; } }

        /// <summary>The image's color table or null if global table is used</summary>
        public IList<Color> LocalColorTable {
            get { return (_parts[1] as ColorTablePart); }
            set {
                if (value == null) {
                    _parts[1] = new ZeroPart();
                    UseLocalColorTable = false;
                    LocalColorTableSize = 0;
                } else {
                    ColorTablePart part = new ColorTablePart(value.ToList());
                    UseLocalColorTable = true;
                    LocalColorTableSize = part.Count;
                    _parts[1] = part;
                }
            }
        }

        private MinimumCodeSizePart MinCodeSizePart { get { return _parts[2] as MinimumCodeSizePart; } }
        /// <summary>The initial number of bits used for LZW codes in the image data</summary>
        public byte MinimumCodeSize { get { return MinCodeSizePart.MinimumCodeSize; } set { MinCodeSizePart.MinimumCodeSize = value; } }

        private GifDataSection DataSection { get { return _parts[3] as GifDataSection; } }
        /// <summary>LWZ compressed image data</summary>
        public byte[] ImageData { get { return DataSection.Content; } set { DataSection.Content = value; } }

        public GifPartLwzImage(GifWrapper wrapper, ref byte[] data, ref int index) {
            this.Wrapper = wrapper;

            // Parse the Header
            _parts.Add(new HeaderPart(ref data, ref index));

            // Parse color table or add a zero part
            if (UseLocalColorTable) {
                _parts.Add(new ColorTablePart(ref data, ref index, LocalColorTableSize));
            } else {
                _parts.Add(new ZeroPart());
            }

            // Parse minimum code size
            _parts.Add(new MinimumCodeSizePart(ref data, ref index));

            // Parse data parts
            _parts.Add(new GifDataSection(ref data, ref index));
        }
        public GifPartLwzImage() {
            _parts.Add(new HeaderPart());
        }
        private GifPartLwzImage(List<GifPart> parts) {
            _parts = parts;
        }
        public GifPartLwzImage(Image img) {
            // Save image to a new GIF container
            GifWrapper wrapper;
            using (MemoryStream ms = new MemoryStream()) {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                wrapper = new GifWrapper(ms.ToArray());
            }

            // Extract LZW image and color table from temporary container
            GifPartHeader header = wrapper.Header;
            if (header == null) throw new Exception("Could not load image as GIF!");
            GifPartLwzImage lwzimg = wrapper.FirstOrDefault(p => p is GifPartLwzImage) as GifPartLwzImage;
            if (lwzimg == null) throw new Exception("Could not extract GIF image data from image!");
            this._parts = lwzimg._parts;

            // Use global color table locally if there is none
            if (!this.UseLocalColorTable && header.UseGlobalColorTable) {
                this.LocalColorTable = header.GlobalColorTable;
            }
        }
        public static GifPartLwzImage GetLwzImagePart(Image img, out byte colorRes) {
            // Save image to a new GIF container
            GifWrapper wrapper;
            using (MemoryStream ms = new MemoryStream()) {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                wrapper = new GifWrapper(ms.ToArray());
            }

            // Extract LZW image and color table from temporary container
            GifPartHeader header = wrapper.Header;
            if (header == null) throw new Exception("Could not load image as GIF!");
            colorRes = header.ColorResolution;
            GifPartLwzImage lwzimg = wrapper.FirstOrDefault(p => p is GifPartLwzImage) as GifPartLwzImage;
            if (lwzimg == null) throw new Exception("Could not extract GIF image data from image!");
            lwzimg.Wrapper = null;

            // Use global color table locally if there is none
            if (!lwzimg.UseLocalColorTable && header.UseGlobalColorTable) {
                lwzimg.LocalColorTable = header.GlobalColorTable;
            }

            return lwzimg;
        }

        public override GifPart CreateCopy() {
            return new GifPartLwzImage(_parts.Select(p => p.CreateCopy()).ToList());
        }

        public Image ToImage() {
            return this.Wrapper == null ? null : this.Wrapper.Extract(this).ToImage();
        }
    }

    /// <summary>A general meta data part (there are several implementations)</summary>
    public class GifPartMetaData : GifPart, GifPart.IGifPartContent {
        protected class HeaderPart : GifPartData {
            public byte Identifier {
                get { return _data[0]; }
                set { _data[0] = value; }
            }
            public byte MetaType {
                get { return _data[1]; }
                set { _data[1] = value; }
            }

            public HeaderPart(ref byte[] data, ref int index) : base(ref data, ref index, 2) { }
            public HeaderPart(byte metaType) {
                _data = new byte[] { 0x21, metaType };
            }
            private HeaderPart(byte[] data) {
                _data = data;
            }

            public override GifPart CreateCopy() {
                byte[] buffer = new byte[_data.Length];
                Array.Copy(_data, buffer, _data.Length);
                return new HeaderPart(buffer);
            }
        }

        private HeaderPart Header { get { return _parts[0] as HeaderPart; } }

        /// <summary>The Meta Data identification 0x21</summary>
        public byte Identifier { get { return Header.Identifier; } set { Header.Identifier = value; } }
        /// <summary>The type of meta data</summary>
        public byte MetaType { get { return Header.MetaType; } set { Header.MetaType = value; } }

        protected GifDataSection Data { get { return _parts[_parts.Count - 1] as GifDataSection; } }
        public byte[] Content { get { return Data == null ? null : Data.Content; } set { if (Data != null) Data.Content = value; } }

        protected GifPartMetaData(ref byte[] data, ref int index) {
            _parts.Add(new HeaderPart(ref data, ref index));
            _parts.Add(new GifDataSection(ref data, ref index));
        }
        protected GifPartMetaData() {

        }
        public GifPartMetaData(byte metaType, byte[] data) {
            _parts.Add(new HeaderPart(metaType));
            _parts.Add(new GifDataSection(data));
        }
        private GifPartMetaData(List<GifPart> parts) {
            _parts = parts;
        }

        public override GifPart CreateCopy() {
            return new GifPartMetaData(_parts.Select(p => p.CreateCopy()).ToList());
        }

        public static GifPartMetaData Parse(ref byte[] data, ref int index) {
            if (data[index] != 0x21) throw new GifParserException(index, string.Format("Not the start of a meta data part: {0:X2}", data[index]));

            GifPartMetaData result = null;
            switch (data[index + 1]) {
                case 0x01:
                    result = new TextDraw(ref data, ref index);
                    break;
                case 0xF9:
                    result = new GraphicsControl(ref data, ref index);
                    break;
                case 0xFE:
                    result = new Comment(ref data, ref index);
                    break;
                case 0xFF:
                    ApplicationData temp = new ApplicationData(ref data, ref index);
                    if (temp.AppIdentifier.Equals("NETSCAPE2.0"))
                        result = new Loop(temp);
                    else
                        result = temp;
                    break;
                default:
                    result = new GifPartMetaData(ref data, ref index);
                    break;
            }

            return result;
        }

        #region Individulized meta data classes

        /// <summary>This can be used to draw plain text onto an image</summary>
        public class TextDraw : GifPartMetaData {
            private class OptionsPart : GifPartData {
                /// <summary>The length of the OptionsPart data section</summary>
                public byte Length {
                    get { return _data[0]; }
                    private set { _data[0] = value; }
                }
                public ushort Left {
                    get { return GetUInt16(1); }
                    set { SetUInt16(1, value); }
                }
                public ushort Top {
                    get { return GetUInt16(3); }
                    set { SetUInt16(3, value); }
                }
                public ushort Width {
                    get { return GetUInt16(5); }
                    set { SetUInt16(5, value); }
                }
                public ushort Height {
                    get { return GetUInt16(7); }
                    set { SetUInt16(7, value); }
                }
                public byte CharWidth {
                    get { return _data[9]; }
                    set { _data[9] = value; }
                }
                public byte CharHeight {
                    get { return _data[10]; }
                    set { _data[10] = value; }
                }
                public byte TextColor {
                    get { return _data[11]; }
                    set { _data[11] = value; }
                }
                public byte BackgroundColor {
                    get { return _data[12]; }
                    set { _data[12] = value; }
                }

                public OptionsPart(ref byte[] data, ref int index) : base(ref data, ref index, data[index] + 1) { }
                public OptionsPart() {
                    _data = new byte[13];
                    _data[0] = 12;
                }
                private OptionsPart(byte[] data) {
                    _data = data;
                }

                public override GifPart CreateCopy() {
                    byte[] buffer = new byte[_data.Length];
                    Array.Copy(_data, buffer, _data.Length);
                    return new OptionsPart(buffer);
                }
            }

            private OptionsPart Options { get { return _parts[1] as OptionsPart; } }

            /// <summary>The horizontal position of the text</summary>
            public ushort Left { get { return Options.Left; } set { Options.Left = value; } }
            /// <summary>The vertical position of the text</summary>
            public ushort Top { get { return Options.Top; } set { Options.Top = value; } }
            /// <summary>The width of the text field</summary>
            public ushort Width { get { return Options.Width; } set { Options.Width = value; } }
            /// <summary>The height of the text field</summary>
            public ushort Height { get { return Options.Height; } set { Options.Height = value; } }
            /// <summary>The charater width</summary>
            public byte CharWidth { get { return Options.CharWidth; } set { Options.CharWidth = value; } }
            /// <summary>The character height</summary>
            public byte CharHeight { get { return Options.CharHeight; } set { Options.CharHeight = value; } }
            /// <summary>The index of the text color</summary>
            public byte TextColor { get { return Options.TextColor; } set { Options.TextColor = value; } }
            /// <summary>The index of the background color</summary>
            public byte BackgroundColor { get { return Options.BackgroundColor; } set { Options.BackgroundColor = value; } }

            public string Text {
                get { return Encoding.ASCII.GetString(Data.Content); }
                set { Data.Content = Encoding.ASCII.GetBytes(value); }
            }

            public TextDraw(ref byte[] data, ref int index) : base() {
                HeaderPart header = new HeaderPart(ref data, ref index);
                if (header.MetaType != 0x01) throw new GifParserException(index - 2, "MetaType does not match the TextMeta-Type 0x01!");
                _parts.Add(header);

                if (data[index] < 12) throw new GifParserException(index, "Text does not hat the required option length!");
                _parts.Add(new OptionsPart(ref data, ref index));

                _parts.Add(new GifDataSection(ref data, ref index));
            }
            public TextDraw(string text) {
                _parts.Add(new HeaderPart(0x01));
                _parts.Add(new OptionsPart());
                _parts.Add(new GifDataSection(Encoding.ASCII.GetBytes(text)));
            }
        }

        public enum DisposalMethods : byte {
            NotSpecified = 0x00,
            DoNotDispose = 0x01,
            RestoreToBGColor = 0x02,
            RestoreToPrevious = 0x03,
            Reserved4 = 0x04,
            Reserved5 = 0x05,
            Reserved6 = 0x06,
            Reserved7 = 0x07
        }

        /// <summary>This can be used to add more options for the folloing image data</summary>
        public class GraphicsControl : GifPartMetaData {
            private class OptionsPart : GifPartData {
                /// <summary>The length of the OptionsPart data section</summary>
                public byte Length {
                    get { return _data[0]; }
                    private set { _data[0] = value; }
                }
                public byte DisposalMethod {
                    get { return Convert.ToByte((_data[1] & 0x1C) >> 2); }
                    set { _data[1] = Convert.ToByte((_data[1] & 0xE3) | ((value & 0x07) << 2)); }
                }
                public bool UseUserInput {
                    get { return (_data[1] & 0x02) != 0; }
                    set { _data[1] = Convert.ToByte((_data[1] & 0xFD) | (value ? 0x02 : 0x00)); }
                }
                public bool UseTransparency {
                    get { return (_data[1] & 0x01) != 0; }
                    set { _data[1] = Convert.ToByte((_data[1] & 0xFE) | (value ? 0x01 : 0x00)); }
                }
                public ushort DelayTime {
                    get { return GetUInt16(2); }
                    set { SetUInt16(2, value); }
                }
                public byte TransparentColor {
                    get { return _data[4]; }
                    set { _data[4] = value; }
                }

                public OptionsPart(ref byte[] data, ref int index) : base(ref data, ref index, data[index] + 2) {
                    if (_data[_data.Length - 1] != 0x00) throw new GifParserException(index - 1, "The Graphics Control meta must not contain more than one data section!");
                }
                public OptionsPart() {
                    _data = new byte[6];
                    _data[0] = 4;
                    _data[5] = 0;
                }
                private OptionsPart(byte[] data) {
                    _data = data;
                }

                public override GifPart CreateCopy() {
                    byte[] buffer = new byte[_data.Length];
                    Array.Copy(_data, buffer, _data.Length);
                    return new OptionsPart(buffer);
                }
            }

            private OptionsPart Options { get { return _parts[1] as OptionsPart; } }

            public DisposalMethods DisposalMethod { get { return (DisposalMethods)Options.DisposalMethod; } set { Options.DisposalMethod = (byte)value; } }
            public bool UseUserInput { get { return Options.UseUserInput; } set { Options.UseUserInput = value; } }
            public bool UseTransparency { get { return Options.UseTransparency; } set { Options.UseTransparency = value; } }
            public ushort DelayTime { get { return Options.DelayTime; } set { Options.DelayTime = value; } }
            public byte TransparentColor { get { return Options.TransparentColor; } set { Options.TransparentColor = value; } }

            public GraphicsControl(ref byte[] data, ref int index) {
                HeaderPart header = new HeaderPart(ref data, ref index);
                _parts.Add(header);
                if (header.MetaType != 0xF9) throw new GifParserException(index - 2, "The Graphics Control meta type does not match 0xF9!");

                if (data[index] < 4) throw new GifParserException(index, "The Graphics Control meta data is too short!");
                _parts.Add(new OptionsPart(ref data, ref index));
            }
            public GraphicsControl() {
                _parts.Add(new HeaderPart(0xF9));
                _parts.Add(new OptionsPart());
            }
        }

        /// <summary>Comment meta data part</summary>
        public class Comment : GifPartMetaData, IGifPartContent {
            public Comment(ref byte[] data, ref int index) : base(ref data, ref index) {
                if (MetaType != 0xFE) throw new GifParserException(index - 1, "The comment meta type must be 0xFE!");
            }
            public Comment(byte[] content) {
                _parts.Add(new HeaderPart(0xFE));
                _parts.Add(new GifDataSection(content));
            }
        }

        /// <summary>Application specific meta data part</summary>
        public class ApplicationData : GifPartMetaData {
            private class OptionsPart : GifPartData {
                public string AppIdentifier {
                    get { return Encoding.ASCII.GetString(_data, 1, _data.Length - 1); }
                    set {
                        byte[] buffer = Encoding.ASCII.GetBytes(value);
                        if (buffer.Length > 255) throw new Exception("The AppIdent must not be longer than 255 characters!");
                        _data = new byte[buffer.Length + 1];
                        _data[0] = Convert.ToByte(buffer.Length);
                        Array.Copy(buffer, 0, _data, 1, buffer.Length);
                    }
                }

                public OptionsPart(ref byte[] data, ref int index) : base(ref data, ref index, data[index] + 1) { }
                public OptionsPart() {
                    _data = new byte[12];
                    _data[0] = 11;
                }
                private OptionsPart(byte[] data) {
                    _data = data;
                }

                public override GifPart CreateCopy() {
                    byte[] buffer = new byte[_data.Length];
                    Array.Copy(_data, buffer, _data.Length);
                    return new OptionsPart(buffer);
                }
            }

            private OptionsPart Options { get { return _parts[1] as OptionsPart; } }

            /// <summary>This should always be 11 bytes long. The first 8 bytes are the name of the application, the other 3 bytes should build a kind of authentification.</summary>
            public string AppIdentifier { get { return Options.AppIdentifier; } set { Options.AppIdentifier = value; } }

            public ApplicationData(ref byte[] data, ref int index) : base() {
                HeaderPart header = new HeaderPart(ref data, ref index);
                _parts.Add(header);
                if (MetaType != 0xFF) throw new GifParserException(index - 1, "The Application meta type does not match 0xFF!");

                _parts.Add(new OptionsPart(ref data, ref index));

                _parts.Add(new GifDataSection(ref data, ref index));
            }
        }

        /// <summary>A specific Application meta part where AppIdetifier is "NETSCAPE2.0" and Parameters are parsed</summary>
        public class Loop : GifPartMetaData {
            private class OptionsPart : GifPartData {
                /// <summary>The length of the OptionsPart data section</summary>
                public override int Length { get { return 11; } }
                public string AppIdentifier { get { return "NETSCAPE2.0"; } set { } }

                public OptionsPart() {
                    _data = new byte[12];
                    _data[0] = 11;

                    byte[] buffer = Encoding.ASCII.GetBytes(AppIdentifier);
                    Array.Copy(buffer, 0, _data, 1, 11);
                }
                private OptionsPart(byte[] data) {
                    _data = data;
                }

                public override GifPart CreateCopy() {
                    byte[] buffer = new byte[_data.Length];
                    Array.Copy(_data, buffer, _data.Length);
                    return new OptionsPart(buffer);
                }
            }

            private class ParametersPart : GifPartData {
                public ushort Iterations {
                    get { return GetUInt16(2); }
                    set { SetUInt16(2, value); }
                }

                public ParametersPart(byte[] originalData) {
                    if (originalData.Length != 3)
                        throw new GifParserException(-1, "The Loop Application parameter data must be 3 bytes!");
                    _data = new byte[5];
                    _data[0] = 3; // Length
                    _data[1] = 1; // Is always 1
                    _data[2] = originalData[1];
                    _data[3] = originalData[2];
                    _data[4] = 0; // Terminating length 0
                }
                public ParametersPart() {
                    _data = new byte[5];
                    _data[0] = 3; // Length
                    _data[1] = 1; // Is always 1
                    _data[2] = 0;
                    _data[3] = 0;
                    _data[4] = 0; // Terminating length 0
                }
                private ParametersPart(byte[] data, bool noop) {
                    _data = data;
                }

                public override GifPart CreateCopy() {
                    byte[] buffer = new byte[_data.Length];
                    Array.Copy(_data, buffer, _data.Length);
                    return new ParametersPart(buffer, true);
                }
            }

            private OptionsPart Options { get { return _parts[1] as OptionsPart; } }
            /// <summary>The AppIdent is NETSCAPE2.0 - the GIF image becomes an animation and the application specific data consists of 3 bytes where the first is always 01 and the 2nd and 3rd bytes specify how many times the animation is to be repeated</summary>
            public string AppIdentifier { get { return Options.AppIdentifier; } }

            private ParametersPart Parameters { get { return _parts[2] as ParametersPart; } }
            /// <summary>The number of repeations - 0 means forever</summary>
            public ushort Iterations { get { return Parameters.Iterations; } set { Parameters.Iterations = value; } }

            public Loop(ApplicationData data) {
                _parts.Add(new HeaderPart(0xFF));
                _parts.Add(new OptionsPart());
                _parts.Add(new ParametersPart(data.Content));
            }
            public Loop() {
                _parts.Add(new HeaderPart(0xFF));
                _parts.Add(new OptionsPart());
                _parts.Add(new ParametersPart());
            }
        }

        #endregion
    }

    /// <summary>The terminating byte of an GIF container (always 0x3B)</summary>
    public class GifPartTerminator : GifPart.GifPartData {
        public GifPartTerminator(ref byte[] data, ref int index) {
            if (data[index] != 0x3B) throw new FormatException("The terminating byte is not 0x3B!");
            _data = new byte[] { 0x3B };
            index++;
        }
        public GifPartTerminator() {
            _data = new byte[] { 0x3B };
        }

        public override GifPart CreateCopy() {
            return new GifPartTerminator();
        }
    }

    /// <summary>Data from after the terminating byte (not part of a valid GIF container)</summary>
    public class GifPartGarbageData : GifPart.GifPartData, GifPart.IGifPartContent {
        public GifPartGarbageData(ref byte[] data, ref int index) {
            using (MemoryStream ms = new MemoryStream()) {
                ms.Write(data, index, data.Length - index);
                _data = ms.ToArray();
            }
            index = data.Length;
        }
        public GifPartGarbageData(byte[] data) {
            _data = data;
        }

        public byte[] Content {
            get { return _data; }
            set { _data = value ?? new byte[0]; }
        }

        public override GifPart CreateCopy() {
            byte[] buffer = new byte[_data.Length];
            Array.Copy(_data, buffer, _data.Length);
            return new GifPartGarbageData(buffer);
        }
    }

    #endregion

    public class GifWrapper : GifPart.GifPartList {
        public GifPartHeader Header { get { return _parts == null || _parts.Count == 0 ? null : _parts[0] as GifPartHeader; } }

        public GifWrapper(string filename) 
            : this(new FileStream(filename, FileMode.Open, FileAccess.Read)) { }
        public GifWrapper(Stream fs) {
            byte[] buffer;
            int len = 0;
            using (MemoryStream ms = new MemoryStream()) {
                buffer = new byte[65536];
                while (fs.Position < fs.Length) {
                    len = fs.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, len);
                }
                buffer = ms.ToArray();
            }

            int index = 0;
            ParsePart(buffer, ref index);
        }
        public GifWrapper(byte[] data) {
            int index = 0;
            ParsePart(data, ref index);
        }
        public GifWrapper() {
            _parts.Add(new GifPartHeader());
            _parts.Add(new GifPartTerminator());
        }
        public GifWrapper(IEnumerable<GifPart> parts) {
            _parts = parts.ToList();
        }
        public GifWrapper(IEnumerable<Image> images, bool animation, GifPartMetaData.DisposalMethods disposalMethod, ushort delayTimeMs, ushort iterations) {
            GifPartHeader header = new GifPartHeader();
            _parts.Add(header);

            if (animation) {
                GifPartMetaData.Loop loop = new GifPartMetaData.Loop();
                loop.Iterations = iterations;
                _parts.Add(loop);
            }

            byte colorRes = 0;
            foreach (Image img in images) {
                GifPartMetaData.GraphicsControl ctrl = new GifPartMetaData.GraphicsControl();
                ctrl.DelayTime = delayTimeMs;
                ctrl.DisposalMethod = disposalMethod;
                _parts.Add(ctrl);


                GifPartLwzImage lwzimg = GifPartLwzImage.GetLwzImagePart(img, out colorRes);
                lwzimg.Wrapper = this;
                _parts.Add(lwzimg);

                if (lwzimg.Width > header.Width) header.Width = lwzimg.Width;
                if (lwzimg.Height > header.Height) header.Height = lwzimg.Height;
                if (colorRes > header.ColorResolution) header.ColorResolution = colorRes;
            }

            _parts.Add(new GifPartTerminator());
        }
        public GifWrapper(IEnumerable<Image> images) : this(images, false, GifPartMetaData.DisposalMethods.NotSpecified, 0, 0) { }

        private void ParsePart(byte[] data, ref int index) {
            bool terminated = false;
            while (index < data.Length) {
                if (terminated) {
                    _parts.Add(new GifPartGarbageData(ref data, ref index));
                } else if (index == 0) { // Start with header
                    _parts.Add(new GifPartHeader(ref data, ref index));
                } else if (data[index] == 0x2C) {  // LWZ Image
                    _parts.Add(new GifPartLwzImage(this, ref data, ref index));
                } else if (data[index] == 0x21) { // Meta part
                    _parts.Add(GifPartMetaData.Parse(ref data, ref index));
                } else if (data[index] == 0x3B) { // Terminator
                    _parts.Add(new GifPartTerminator(ref data, ref index));
                    terminated = true;
                } else {
                    throw new GifParserException(index, string.Format("Failed to parse GIF: 0x{0:X2} is not a valid part identifier!", data[index]));
                }
            }
        }

        private GifWrapper CreateGif(GifPartMetaData.GraphicsControl graphicCrtl, GifPartLwzImage image) {
            List<GifPart> parts = new List<GifPart>();
            parts.Add(Header.CreateCopy());
            if (graphicCrtl != null) {
                parts.Add(graphicCrtl.CreateCopy());
            }
            parts.Add(image);
            parts.Add(new GifPartTerminator());
            return new GifWrapper(parts);
        }

        public GifWrapper Extract(GifPartLwzImage frame) {
            // Search the last graphics control before the frame
            GifPartMetaData.GraphicsControl gc = null;
            bool imgFound = false;
            foreach (GifPart p in _parts) {
                if (p is GifPartMetaData.GraphicsControl) gc = p as GifPartMetaData.GraphicsControl;
                if (p == frame) {
                    imgFound = true;
                    break;
                }
            }
            if (!imgFound) gc = null;

            List<GifPart> parts = new List<GifPart>();
            parts.Add(Header.CreateCopy());
            if (gc != null) {
                parts.Add(gc.CreateCopy());
            }
            parts.Add(frame.CreateCopy());
            parts.Add(new GifPartTerminator());
            return new GifWrapper(parts);
        }

        public Image ToImage() {
            byte[] data = this.GetData();
            Image result = Image.FromStream(new MemoryStream(data));
            return result;
        }

        public override GifPart CreateCopy() {
            return new GifWrapper(_parts.Select(p => p.CreateCopy()));
        }

        public void SetDelayTime(ushort delayTime) {
            foreach (GifPart part in _parts) {
                if (part is GifPartMetaData.GraphicsControl) {
                    GifPartMetaData.GraphicsControl ctrl = part as GifPartMetaData.GraphicsControl;
                    ctrl.DelayTime = delayTime;
                }
            }
        }

    }

}
