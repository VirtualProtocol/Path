namespace Path.Character.Models
{
    public class CharacterModel
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }
        public int AbilitiesId { get; set; }
        public int RaceId { get; set; }
        public int TraitsId { get; set; }
        public int AlignmentId { get; set; }
        public int AccountId { get; set; }

        public string CharacterName { get; set; }
    }
}
