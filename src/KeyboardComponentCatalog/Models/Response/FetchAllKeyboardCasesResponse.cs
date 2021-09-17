using System.Collections.Generic;
using KeyboardComponentCatalog.Models.Dto;

namespace KeyboardComponentCatalog.Models.Response
{
    public class FetchAllKeyboardCasesResponse
    {
        public ICollection<CaseDto> KeyboardCases { get; set; }   
    }
}