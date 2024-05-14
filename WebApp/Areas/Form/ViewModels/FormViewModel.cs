using System.ComponentModel.DataAnnotations;
using App.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Form.ViewModels;

public class FormViewModel
{
    [MinLength(2)] public string Name { get; set; } = default!;

    public MultiSelectList? SelectedSectors { get; set; }

    public bool AgreesToTerms { get; set; }

    public List<string> SectorIds { get; set; } = default!;
}