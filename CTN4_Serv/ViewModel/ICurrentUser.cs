using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
	public interface ICurrentUser
	{
		Guid Id { get; }
		string UserName { get; }
		string Name { get; }
		string Email { get; }
		List<string> RoleCodes { get; }
	}
}
