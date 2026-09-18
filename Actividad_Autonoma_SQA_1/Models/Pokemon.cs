namespace Actividad_Autonoma_SQA_1.Models
{
    public class PokemonApiResponse
    {
        public int Count { get; set; }
        public List<PokemonSummary> Results { get; set; } = new();
    }

    public class PokemonSummary
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public int Id
        {
            get
            {
                if (string.IsNullOrEmpty(Url)) return 1;
                var segments = Url.TrimEnd('/').Split('/');
                return int.TryParse(segments.Last(), out var id) ? id : 1;
            }
        }

        public string ImageUrl => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/{Id}.png";
    }

    public class PokemonDetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<PokemonTypeSlot> Types { get; set; } = new();
        public List<PokemonStatSlot> Stats { get; set; } = new();
        public string OfficialArtwork => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/{Id}.png";
    }

    public class PokemonTypeSlot
    {
        public PokemonTypeInfo Type { get; set; } = new();
    }

    public class PokemonTypeInfo
    {
        public string Name { get; set; } = string.Empty;
    }

    public class PokemonStatSlot
    {
        public int BaseStat { get; set; }
        public PokemonStatInfo Stat { get; set; } = new();
    }

    public class PokemonStatInfo
    {
        public string Name { get; set; } = string.Empty;
    }
}