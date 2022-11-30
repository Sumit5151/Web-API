
using AutoMapper;
using Web_API.Dtos.Character;

namespace Web_API.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        public static List<Character> Characters = new List<Character>(){
            new Character(),
            new Character{Id=1,Name="Sam"}
            };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = Characters.Max(x => x.Id) + 1;
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Characters.Add(character);
            serviceResponse.Data = Characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>()
            {
                Data = Characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {

            var serviceResponse = new ServiceResponse<GetCharacterDto>()
            {
                Data = _mapper.Map<GetCharacterDto>(Characters.FirstOrDefault(x => x.Id == id))
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = Characters.FirstOrDefault(x => x.Id == updateCharacterDto.Id);

                _mapper.Map(updateCharacterDto, character);
                //character.Name = updateCharacterDto.Name;
                //character.HitPointes = updateCharacterDto.HitPointes;
                //character.Strength = updateCharacterDto.Strength;
                //character.Defence = updateCharacterDto.Defence;
                //character.Intelligence = updateCharacterDto.Intelligence;
                //character.Class = updateCharacterDto.Class;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var response = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                var character = Characters.First(x=>x.Id== id);
                Characters.Remove(character);
                response.Data = Characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}