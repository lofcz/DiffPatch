        private readonly List<FileDiff> files = [];
        private Chunk? current;
        private FileDiff? file;
            foreach (string? line in lines)
            {
                string trimmedLine = line;

                if (trimmedLine.EndsWith("\r"))
                {
                    trimmedLine = line.Substring(0, line.Length - 1);
                }
                
                if (!ParseLine(trimmedLine))
                {
                    ParseNormalLine(trimmedLine);
                }
            }
        private void Start(string? line)

            if (file is not null)
            {
                file.Type = FileChangeType.Add;
                file.From = devnull;
            }

            if (file is not null)
            {
                file.Type = FileChangeType.Delete;
                file.To = devnull;
            }

            if (file is not null)
            {
                file.Index = line.Split(' ').Skip(1);                
            }

            if (file is not null)
            {
                file.From = ParseFileName(line);   
            }

            if (file is not null)
            {
                file.To = ParseFileName(line);
            }

            if (file is not null)
            {
                file.Type = FileChangeType.Modified;   
            }
            file?.Chunks.Add(current);
            current?.Changes.Add(new LineDiff(type: LineChangeType.Delete, index: in_del++, content: content));

            if (file is not null)
            {
                file.Deletions++;   
            }
            current?.Changes.Add(new LineDiff(type: LineChangeType.Add, index: in_add++, content: content));

            if (file is not null)
            {
                file.Additions++;   
            }
            if (file is null || string.IsNullOrEmpty(line) || current is null) return;
        private static readonly Regex FileNameRegex = new Regex(@"^(a|b)\/", RegexOptions.Compiled);
        private static readonly Regex TimestampRegex = new Regex(@"\t.*|\d{4}-\d\d-\d\d\s\d\d:\d\d:\d\d(.\d+)?\s(\+|-)\d\d\d\d", RegexOptions.Compiled);
        private static readonly Regex GitPrefixRegex = new Regex(@"^(a|b)\/", RegexOptions.Compiled);
        
        private static string[]? ParseFileNames(string? s)
            return s!
                .Select(fileName => FileNameRegex.Replace(fileName, string.Empty)).ToArray();
            var t = TimestampRegex.Match(s);
            return GitPrefixRegex.IsMatch(s) ? s.Substring(2) : s;
            private readonly List<HandlerRow> handlers = new List<HandlerRow>();