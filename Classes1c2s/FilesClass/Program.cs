var currentDirectory = Directory.GetCurrentDirectory();
var archivePath = Path.Combine(currentDirectory, "Archive");
if (!Directory.Exists(archivePath))
    Directory.CreateDirectory(archivePath);

var userFolder = Path.Combine("C:", "Users", "andre");
var files = Directory.Exists(userFolder)
    ? Directory.GetFiles(userFolder)
    : [];
foreach (var file in files)
{
    var extension = Path.GetExtension(file);
    if (extension == ".log")
        File.Copy(file, Path.Combine(archivePath, Path.GetFileName(file)));
}