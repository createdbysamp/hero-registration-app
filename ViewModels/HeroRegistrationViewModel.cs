namespace HeroRegistrationForm.ViewModels;

public class HeroRegistrationViewModel
{
    // private data
    private int _level;

    // public classes
    public required string Name { get; set; }
    public required string HeroType { get; set; }
    public required int Level
    {
        get => _level;
        set
        {
            if (value < 1 || value > 100)
            {
                throw new Exception("Level must be between 1 & 100.. Nerd..");
            }
            _level = value;
        }
    }
    public required string Email { get; set; }
}
