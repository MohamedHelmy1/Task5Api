using Task4Api.Model;

namespace Task4Api.Repository
{
    public class ProductRepositery
    {
        private readonly Task4DbContext db;

        public ProductRepositery(Task4DbContext db)
        {
            this.db = db;
        }
        
    }
}
