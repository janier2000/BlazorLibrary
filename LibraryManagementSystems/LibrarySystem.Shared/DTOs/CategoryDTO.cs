namespace LibrarySystem.Shared.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public override bool Equals(object? o)
        {
            var other = o as CategoryDTO;
            return other?.Id == Id;
        }
        public override int GetHashCode() => Id.GetHashCode();
        public override string ToString()
        {
            return Description!;
        }
    }
}