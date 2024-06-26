﻿using System.Collections.Generic;

namespace DiffPatch.Data
{
    public class FileDiff
    {
        public ICollection<Chunk> Chunks { get; } = new List<Chunk>();

        public int Deletions { get; set; }
        public int Additions { get; set; }

        public string? To { get; set; }

        public string? From { get; set; }

        public FileChangeType Type { get; set; }

        public bool Deleted => Type == FileChangeType.Delete;

        public bool Add => Type == FileChangeType.Add;

        public IEnumerable<string>? Index { get; set; }
    }
}
