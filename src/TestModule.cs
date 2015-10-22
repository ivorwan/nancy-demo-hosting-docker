namespace Nancy.Demo.Hosting.Docker
{
    public class TestModule : NancyModule
    {
        public TestModule()
        {
            Get["/"] = parameters => {
                System.Console.WriteLine("Visit / on " + System.Environment.MachineName);
                return View["staticview", Request.Url];
            };

            Get["/machine"] = parameters =>
            {
                System.Console.WriteLine("Visit /machine on " + System.Environment.MachineName);
                return System.Environment.MachineName + "\r\n";
            };


            Get["/masterswitch/get/{id}"] = parameters =>
            {
                bool enabled = Session[parameters.id] == null ? false : (bool)Session[parameters.id];

                return "Portal " + parameters.id + " is " + enabled;
            };

            Get["/masterswitch/post/{id}/{enabled}"] = parameters =>
            {
                Session[parameters.id] = (bool)parameters.enabled;
                return "Setting portal " + parameters.id + " to " + parameters.enabled;
            };
        }
    }
}
