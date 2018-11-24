using AutoMapper;
using PRCN.Clan.DB;
using PRCN.Clan.Model.ApiModel.AttackRecord;
using PRCN.Clan.Model.ApiModel.Boss;
using PRCN.Clan.Model.ApiModel.Member;
using PRCN.Clan.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRCN.Clan.Api.App_Start
{
    public class AutoMapperConfigFile : Profile
    {
        public AutoMapperConfigFile()
        {
            CreateMap<MemberBM, Member>().ReverseMap();
            CreateMap<Member, MemberBM>().ReverseMap();
            CreateMap<Member, MemberAM>().ReverseMap();
            CreateMap<BossBM, Boss>().ReverseMap();
            CreateMap<Boss, BossBM>().ReverseMap();
            CreateMap<Boss, BossAM>().ReverseMap();
            CreateMap<AttackRecordBM, AttackRecord>().ReverseMap();
            CreateMap<AttackRecord, AttackRecordBM>().ReverseMap();
            CreateMap<AttackRecord, AttackRecordAM>()
                .ForMember(c => c.MemberName, y => y.MapFrom(s => s.Member.Name))
                .ForMember(c => c.BossName, y => y.MapFrom(s => s.Boss.Name))
                .ForMember(c => c.IsKillSteal, y => y.MapFrom(s => s.IsKillSteal ? "是" : "否"))
                .ForMember(c => c.AttackDate, y => y.MapFrom(s => s.AttackDate.ToString("yyyy/MM/dd")))
                .ForMember(c => c.MemberID, y => y.MapFrom(s => s.Member.ID)).ReverseMap();
            //    .ForMember(c => c.Birthday, y => y.MapFrom(s => s.Birthday.HasValue ? s.Birthday.Value.ToString("yyyy/MM/dd") : ""))
            //    .ForMember(c => c.Gender, y => y.MapFrom(s => ((GenderEnum)s.Gender).GetDisplayName()))
            //.ForMember(c => c.IsOn, y => y.MapFrom(s => s.IsOn ? NgApiResource.On : NgApiResource.Off)).ReverseMap();
        }
    }
}