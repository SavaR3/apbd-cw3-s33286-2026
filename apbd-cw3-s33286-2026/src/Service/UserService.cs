namespace apbd_cw3_s33286_2026.Service;

using apbd_cw3_s33286_2026.Model;

public class UserService
{
    private readonly Data _db;

    public UserService(Data db)
    {
        _db = db;
    }

    public void RegisterUser(User user) => _db.Users.Add(user);

    public List<User> GetAllUsers() => _db.Users;
    
    public User? GetById(Guid id) => _db.Users.FirstOrDefault(u => u.Id == id);
}