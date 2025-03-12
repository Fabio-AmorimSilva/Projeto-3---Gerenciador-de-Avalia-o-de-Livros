namespace BookReviewManagement.Domain.Entities;

public class User : Entity
{
    public const int MaxNameLength = 150;

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    private readonly List<Review> _reviews = [];
    public IReadOnlyCollection<Review> Reviews => _reviews;

    protected User(){}
    
    public User(
        string name,
        string email,
        string password
    )
    {
        Guard.IsNotWhiteSpace(name);
        Guard.IsLessThanOrEqualTo(name.Length, MaxNameLength, nameof(name));
        Guard.IsNotWhiteSpace(email);
        Guard.IsNotWhiteSpace(password);

        Name = name;
        Email = email;
        Password = password;
    }

    public void Update(
        string name,
        string email
    )
    {
        Guard.IsNotWhiteSpace(name);
        Guard.IsLessThanOrEqualTo(name.Length, MaxNameLength, nameof(name));
        Guard.IsNotWhiteSpace(email);

        Name = name;
        Email = email;
    }

    public void AddReview(Review review)
    {
        _reviews.Add(review);
    }
    
    public void UpdatePassword(string password)
    {
        Guard.IsNotWhiteSpace(password);
        
        Password = password;
    }
}