using AccountantAppWebAPI.ViewModel;
using AutoMapper;
using Model;

namespace AccountantAppWebAPI.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Operation, OperationDto>()
				.ForMember(dto => dto.Account,
					e => e.MapFrom(x => x.Account.Name))
				.ForMember(dto => dto.Wallet,
					e => e.MapFrom(x => x.Wallet.Name));
		}
	}
}
