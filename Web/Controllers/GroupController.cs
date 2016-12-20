using Core;
using Infrastructure;

namespace Web.Controllers
{
    public class GroupController : AbstractController<Group>
    {
        public GroupController()
        {
            Repository = new GroupRepository();
        }
    }
}