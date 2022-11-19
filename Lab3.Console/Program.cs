// See https://aka.ms/new-console-template for more information
using Lab3.Console;
using Lab3.Hash;

var projectFolder = @"D:\NURE\7\BPtD\Lab3\Lab3\Lab3.Console";

var wordFilePath = Path.GetFullPath("./Files/word.docx", projectFolder);
var sourceCodeFilePath = Path.GetFullPath("./Files/SourceCode.cs", projectFolder);
var imageFilePath = Path.GetFullPath("./Files/image.png", projectFolder);

var wordFile = await MessageReader.ReadBytes(wordFilePath);
var sourceCodeFile = await MessageReader.ReadBytes(sourceCodeFilePath);
var imageFile = await MessageReader.ReadBytes(imageFilePath);

Console.WriteLine("\t\t\t=== 2 BITS (Word) ===");
var hashFunction2bits = new HashFunction(2);
var result2bits = hashFunction2bits.Calculate(wordFile);
Console.WriteLine($"{result2bits}");
Console.WriteLine($"Average unique bits: {hashFunction2bits.CheckMixing(wordFile)}%");
Console.WriteLine($"Messages count with the same hash: {CollisionFinder.GetMessages(hashFunction2bits, wordFile).Count}\n\n");

Console.WriteLine("\t\t\t=== 4 BITS (Word) ===");
var hashFunction4bits = new HashFunction(4);
var result4bits = hashFunction4bits.Calculate(wordFile);
Console.WriteLine($"{result4bits}");
Console.WriteLine($"Average unique bits: {hashFunction4bits.CheckMixing(wordFile)}%");
Console.WriteLine($"Messages count with the same hash: {CollisionFinder.GetMessages(hashFunction4bits, wordFile).Count}\n\n");

Console.WriteLine("\t\t\t=== 8 BITS (Word) ===");
var hashFunction8bits = new HashFunction(8);
var result8bits = hashFunction8bits.Calculate(wordFile);
Console.WriteLine($"{result8bits}");
Console.WriteLine($"Average unique bits: {hashFunction8bits.CheckMixing(wordFile)}%");
Console.WriteLine($"Messages count with the same hash: {CollisionFinder.GetMessages(hashFunction8bits, wordFile).Count}\n\n");

Console.WriteLine("\t\t\t=== 2 BITS (Source Code) ===");
result2bits = hashFunction2bits.Calculate(sourceCodeFile);
Console.WriteLine($"{result2bits}");
Console.WriteLine($"Average unique bits: {hashFunction2bits.CheckMixing(sourceCodeFile)}%\n\n");

Console.WriteLine("\t\t\t=== 4 BITS (Source Code) ===");
result4bits = hashFunction4bits.Calculate(sourceCodeFile);
Console.WriteLine($"{result4bits}");
Console.WriteLine($"Average unique bits: {hashFunction4bits.CheckMixing(sourceCodeFile)}%\n\n");

Console.WriteLine("\t\t\t=== 8 BITS (Source Code) ===");
result8bits = hashFunction8bits.Calculate(sourceCodeFile);
Console.WriteLine($"{result8bits}");
Console.WriteLine($"Average unique bits: {hashFunction8bits.CheckMixing(sourceCodeFile)}%\n\n");

Console.WriteLine("\t\t\t=== 2 BITS (Image) ===");
result2bits = hashFunction2bits.Calculate(imageFile);
Console.WriteLine($"{result2bits}");
Console.WriteLine($"Average unique bits: {hashFunction2bits.CheckMixing(imageFile)}%\n\n");

Console.WriteLine("\t\t\t=== 4 BITS (Image) ===");
result4bits = hashFunction4bits.Calculate(imageFile);
Console.WriteLine($"{result4bits}");
Console.WriteLine($"Average unique bits: {hashFunction4bits.CheckMixing(imageFile)}%\n\n");

Console.WriteLine("\t\t\t=== 8 BITS (Image) ===");
result8bits = hashFunction8bits.Calculate(imageFile);
Console.WriteLine($"{result8bits}");
Console.WriteLine($"Average unique bits: {hashFunction8bits.CheckMixing(imageFile)}%\n\n");