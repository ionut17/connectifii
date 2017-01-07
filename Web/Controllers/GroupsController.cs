using Core;
using Infrastructure;

namespace Web.Controllers
{
    public class GroupsController : AbstractController<Group>
    {
        public GroupsController()
        {
            Repository = new GroupRepository();
        }
    }
}