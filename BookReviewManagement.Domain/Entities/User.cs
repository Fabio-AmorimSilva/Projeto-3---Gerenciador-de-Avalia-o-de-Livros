namespace BookReviewManagement.Domain.Entities;

public class User : Entity
{
    public int Score { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    
    private readonly List<Review> _reviews = [];
    public IReadOnlyCollection<Review> Reviews => _reviews;

    public User(
        int score, 
        string name, 
        string email,
        string password
    )
    {
        Score = score;
        Name = name;
        Email = email;
        Password = password;
    }
}