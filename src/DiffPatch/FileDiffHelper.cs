        private const string noeol = "\\ No newline at end of file";
            if (!lines.Any()) return Array.Empty<FileDiff>();
            Chunk? current = null;
            FileDiff? file = null;
            void Start(string? line, Match? m)
            {
            }
            void Restart()
            {
                if (file == null || file.Chunks.Count != 0) Start(null, null);
            }
            void NewFile(string line, Match m)
            {
                Restart();
                if (file is not null)
                {
                    file.Type = FileChangeType.Add;
                    file.From = "/dev/null";
                }
            }
            void DeletedFile(string line, Match m)
            {
                Restart();
                if (file is not null)
                {
                    file.Type = FileChangeType.Delete;
                    file.To = "/dev/null";   
                }
            }
            void Index(string line, Match m)
            {
                Restart();

                if (file is not null)
                {
                    file.Index = line.Split(' ').Skip(1);   
                }
            }

            void FromFile(string line, Match m)
            {
                Restart();
                if (file is not null)
                {
                    file.From = parseFileFallback(line);   
                }
            }

            void ToFile(string line, Match m)
            {
                Restart();

                if (file is not null)
                {
                    file.To = parseFileFallback(line);   
                }
            }
            
            void Chunk(string line, Match match)
            {
                ChunkRangeInfo rangeInfo = new ChunkRangeInfo(new ChunkRange(oldStart, oldLines), new ChunkRange(newStart, newLines));
                file?.Chunks.Add(current);
            }
            void Del(string line, Match match)
            {
                if (current is null || file is null)
                {
                    return;
                }
                
            }
            void Add(string line, Match m)
            {
                if (current is null || file is null)
                {
                    return;
                }
                
            }
            
            void Normal(string line)
            {
                if (file is null || current is null) return;
                
                current.Changes.Add(new LineDiff(oldIndex: line == noeol ? 0 : in_del++, newIndex: line == noeol ? 0 : in_add++, content: content));
            }
                { new Regex(@"^diff\s"), Start },
                { new Regex(@"^new file mode \d+$"), NewFile },
                { new Regex(@"^deleted file mode \d+$"), DeletedFile },
                { new Regex(@"^index\s[\da-zA-Z]+\.\.[\da-zA-Z]+(\s(\d+))?$"), Index },
                { new Regex(@"^---\s"), FromFile },
                { new Regex(@"^\+\+\+\s"), ToFile },
                { new Regex(@"^@@\s+\-(\d+),?(\d+)?\s+\+(\d+),?(\d+)?\s@@"), Chunk },
                { new Regex(@"^-"), Del },
                { new Regex(@"^\+"), Add }
            bool Func(string line)
            {
            }
                if (!Func(line))
                    Normal(line);
        private static string[]? parseFile(string? s)
            return s!