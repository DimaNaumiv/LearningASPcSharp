using Claswork_ASP_APP.MyClasses;

namespace Claswork_ASP_APP.Serves
{
	public interface IProfileServis
	{
		bool Save(ProfileDTO profile);
		List<ProfileDTO> GetAll();
		ProfileDTO GetLastProfile();
		ProfileDTO GetFirstProfile();
		ProfileDTO GetById(int Id);
	}
}
