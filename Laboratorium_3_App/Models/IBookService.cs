namespace Laboratorium_3_App.Models
{
    public interface IContactService
    {
        void Add(Contact book);
        void Delete(int id);    
        void Update(Contact book);
        List<Contact> FindAll();
        Contact? FindById (int id); 
    }
}
