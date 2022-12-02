using AutoMapper;
using WebApiLoteria.DTOs;
using WebApiLoteria.Entidades;

namespace WebApiLoteria.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearRifaDTO, Rifa>();
            CreateMap<Rifa, RifaDTO>();
            //CreateMap<Rifa, RifaDTOConParticipantes>()
            //    .ForMember(rifaDTO => rifaDTO.Participantes, opciones => opciones.MapFrom(MapRifaDTOParticipante));
            //CreateMap<CrearParticipanteDTO, Participante>()
            //    .ForMember(participante => participante.RifasParticipantes, opciones => opciones.MapFrom(MapRifaParticipante));

            CreateMap<Participante, ParticipanteDTO>();
            //CreateMap<Participante, ParticipantesDTOConRifas>()
            //    .ForMember(participanteDTO => participanteDTO.Rifas, opciones => opciones.MapFrom(MapParticipanteDTORifas));
            CreateMap<ParticipantePatchDTO, Participante>().ReverseMap();

            CreateMap<CrearParticipanteDTO, Rifa>();
            CreateMap<CrearParticipanteDTO, Participante>();
            CreateMap<ParticipanteDTO, Rifa>();
            CreateMap<ParticipanteDTO, Participante>();
            CreateMap<Participante, GetParticipantesDTO>();
            CreateMap<Rifa, GetRifasDTO>();
            CreateMap<PremioDTO, Premio>();
            CreateMap<Premio, GetPremioDTO>();  
        }

        //private List<RifaParticipante> MapRifaParticipante(CrearParticipanteDTO crearParticipanteDTO, Participante participante)
        //{
        //    var result = new List<RifaParticipante>();

        //    if (crearParticipanteDTO.RifasIds == null)
        //    {
        //        return result;
        //    }
        //    foreach (var participanteId in crearParticipanteDTO.RifasIds)
        //    {
        //        result.Add(new RifaParticipante() { ParticipanteId = participanteId });
        //    }

        //    return result;

        //}

        //private List<ParticipanteDTO> MapParticipanteDTORifas(Participante participante, ParticipanteDTO participanteDTO)
        //{
        //    var result = new List<ParticipanteDTO>();
        //    if (participante.RifasParticipantes == null) { return result; }
        //    foreach (var participanterifa in participante.RifasParticipantes)
        //    {
        //        result.Add(new ParticipanteDTO()
        //        {
        //            Id = participanterifa.ParticipanteId,
        //            Nombre = participanterifa.Participante.Nombre,
        //        });
        //    }
        //    return result;
        //}

        //private List<RifaDTO> MapRifaDTOParticipante(Rifa rifa, RifaDTO rifaDTO)
        //{
        //    var result = new List<RifaDTO>();

        //    if (rifa.RifasParticipantes == null) { return result; }

        //    foreach (var rifaparticipante in rifa.RifasParticipantes)
        //    {
        //        result.Add(new RifaDTO()
        //        {
        //            Id = rifaparticipante.RifaId,
        //            NombreRifa = rifaparticipante.Rifa.NombreRifa

        //        });
        //    }

        //    return result;
        //}
    }
}
