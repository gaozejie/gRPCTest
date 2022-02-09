// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcService;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

//var channel = GrpcChannel.ForAddress("https://localhost:7145"); // 服务端地址
//var client = new Greeter.GreeterClient(channel);
//var reply = await client.SayHelloAsync(new HelloRequest { Name = "张三" });
//Console.WriteLine("Greeter 服务返回数据: " + reply.Message);
//Console.ReadKey();


var channel = GrpcChannel.ForAddress("https://localhost:7145"); // 服务端地址
var client = new User.UserClient(channel);
var reply = await client.RegisterAsync(new UserDTO { Account = "zhangsan", Pwd = "123", Name = "张三", Age = 18 });
Console.WriteLine("User 服务 RegisterAsync 方法返回数据: " + JsonConvert.SerializeObject(reply));
Console.ReadKey();

var reply1 = await client.RegisterAsync(new UserDTO { Account = "lisi", Pwd = "123", Name = "李四", Age = 20 });
Console.WriteLine("User 服务 RegisterAsync 返回数据: " + JsonConvert.SerializeObject(reply1));
Console.ReadKey();

var reply2 = await client.GetAllUserAsync(new Google.Protobuf.WellKnownTypes.Empty());
Console.WriteLine("User 服务 GetAllUserAsync 返回数据: " + JsonConvert.SerializeObject(reply2));
Console.ReadKey();

var reply3 = await client.LoginAsync(new LoginDTO() { Accont = "zhangsan", Pwd = "123" });
Console.WriteLine("User 服务 LoginAsync 返回数据: " + JsonConvert.SerializeObject(reply3));
Console.ReadKey();

var reply4 = await client.LogoutAsync(new LogoutDTO() { Token = "TestToken" });
Console.WriteLine("User 服务 LogoutAsync 返回数据: " + JsonConvert.SerializeObject(reply4));
Console.ReadKey();