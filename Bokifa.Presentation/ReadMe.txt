Presentation ozune saxliyir
1.Controllers (sealed istifade olunmlidi miras alina bilinmeyen olsun)
2.Abstraction(ApiController.cs)
Not: ApiController:ControllerBase => using AspNetCore.MVC.Core yuxarisinda [ApiController] , [Route("api/[controller]")]
AssemblyReference.cs
public static class AssemblyReference
{
public static readonly Assembly Assembly= typeof(AssemblyReference).Assembly    Not: Reference olmayada biler
}
3.PresentationServiecRegistration.cs
