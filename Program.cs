using System.IO;

var fileName = "recipes";
var Format = FileFormat.Txt;

IStringsRepository stringRepo = Format==FileFormat.Json ? new StringsJsonRepository() : new StringsTextualRepository();

var ingredientRegister = new IngredientRegister();


var fileMetaData = new FileMetaData(fileName,Format);

var cookieApp = new CookieApp(new ConsoleUserInteractions(ingredientRegister), new RecipeRepository(stringRepo,ingredientRegister));


cookieApp.Run(fileMetaData.ToPath());
