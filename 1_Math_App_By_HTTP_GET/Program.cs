var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    context.Response.ContentType = "text/Number";
    bool flag = false;
    if (context.Request.Method == HttpMethods.Get)
    {
        int num1 = 0, num2 = 0;
        int result = 0;
        if (context.Request.Query.ContainsKey("firstNumber"))
        {
            // Use null-coalescing operator to handle potential null values
            string firstNumber = context.Request.Query["firstNumber"].ToString() ?? string.Empty;
            if (!int.TryParse(firstNumber, out num1))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid value for firstNumber.\n");
                flag = true;
            }
        }
        else
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
            flag = true;
        }

        if (context.Request.Query.ContainsKey("secondNumber")) 
        {
            string secondNumber = context.Request.Query["secondNumber"].ToString() ?? string.Empty;
            if (!int.TryParse(secondNumber, out num2))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid value for secondNumber.\n");
                flag = true;
            }

        }
        else
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
            flag = true;
        }

        if (context.Request.Query.ContainsKey("operation") && context.Request.Query["operation"] == "add")
        {
            if(!flag)
            {
             result = num1 + num2;
             await context.Response.WriteAsync($"The sum of {num1} and {num2} is {result}\n");
            }
        }
        else if (context.Request.Query.ContainsKey("operation") && context.Request.Query["operation"] == "subtract")
        {
            if (!flag)
            {
                result = num1 - num2;
                await context.Response.WriteAsync($"The difference of {num1} and {num2} is {result}\n");
            }
        }
        else if (context.Request.Query.ContainsKey("operation") && context.Request.Query["operation"] == "multiply")
        {
            if (!flag)
            {
                result = num1 * num2;
                await context.Response.WriteAsync($"The product of {num1} and {num2} is {result}\n");
            }
        }
        else if (context.Request.Query.ContainsKey("operation") && context.Request.Query["operation"] == "divide")
        {
            if (!flag)
            {
                if (num2 != 0)
                {
                    if (!flag)
                    {
                        result = num1 / num2;
                        await context.Response.WriteAsync($"The quotient of {num1} and {num2} is {result}\n");
                    }
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Division by zero is not allowed.\n");
                }
            }
        }
        else
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for operation. Supported operations are: add, subtract, multiply, divide.\n");
        }

    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Unsupported HTTP method.\n");
    }
    //if(flag) context.Response.StatusCode = 400;
});

app.Run();
