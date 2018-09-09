using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MokeponStatsParser
{
    internal class CsvHandler
    {
        public CsvHandler()
        {
        }

        public bool HandleInput(string input, string output)
        {
            // Pokémon,Dex #,Item,Ability ,Move A,Move B,Move C,Move D,Nature,IVs *,HP,Atk,Def,Sp.Atk,Sp.Def,Speed,Notes
            var lines = input.Split('\n').Skip(1);

            var mokepons = new List<Mokepon>();

            foreach (var line in lines)
            {
                var mon = new Mokepon();
                var info = line.Split(',');
                mon.Species = info[0];
                mon.Displayname = $"\"{info[0]}-1.2\"";
                mon.Ability = $"[{info[3]}]";
                mon.SetName = "[Token1.2]";
                mon.Tag = "[PBR1.2]";
                mon.Item = $"[Null]";
                mon.Nature = $"{info[8]}";
                mon.IVs = $"{info[9]}";
                mon.Moves = GetMoves(info);
                mon.Gender = $"[M,F]";
                mon.Rarity = $"[1.0]";

                mokepons.Add(mon);
            }

            if (!mokepons.Any()) return false;

            return ExportToFile(mokepons, output);
        }

        private bool ExportToFile(List<Mokepon> mokepons, string output)
        {
            var s = new StringBuilder();
            foreach (var mon in mokepons)
            {
                s.AppendLine($"species: {mon.Species}");
                s.AppendLine($"displayname: {mon.Displayname}");
                s.AppendLine($"setname: {mon.SetName}");
                s.AppendLine($"tags: {mon.Tag}");
                s.AppendLine($"item: {mon.Item}");
                s.AppendLine($"ability: {mon.Ability}");
                s.AppendLine($"nature: {mon.Nature}");
                s.AppendLine($"ivs: {mon.IVs}");
                s.AppendLine($"moves: \n{mon.Moves}");
                s.AppendLine($"gender: {mon.Gender}");
                s.AppendLine($"rarity: {mon.Rarity}");
                s.AppendLine($"---");
            }

            try
            {
                File.WriteAllText(output, s.ToString());
            }
            catch
            {
                Console.WriteLine("Failed to save file.");
                return false;
            }

            return true;
        }

        private string GetMoves(string[] info)
        {
            var moves = new StringBuilder();
            if (!string.IsNullOrEmpty(info[4])) moves.AppendLine($"\t- [{info[4]}]");
            if (!string.IsNullOrEmpty(info[5])) moves.AppendLine($"\t- [{info[5]}]");
            if (!string.IsNullOrEmpty(info[6])) moves.AppendLine($"\t- [{info[6]}]");
            if (!string.IsNullOrEmpty(info[7])) moves.Append($"\t- [{info[7]}]");

            return moves.ToString();
        }
    }
}