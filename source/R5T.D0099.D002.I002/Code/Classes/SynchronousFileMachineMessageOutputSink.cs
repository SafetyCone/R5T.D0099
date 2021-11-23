using System;
using System.IO;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using R5T.Magyar.IO;

using R5T.D0096;
using R5T.D0098;
using R5T.T0091;

using R5T.D0099.T001;


namespace R5T.D0099.D002.I002
{
    public class SynchronousFileMachineMessageOutputSink : IMachineMessageOutputSink
    {
        private ILogger Logger { get; }

        private IHumanOutput HumanOutput { get; }
        private IMachineMessageJsonReserializer MachineMessageJsonReserializer { get; }


        private FileStream FileStream { get; }


        public SynchronousFileMachineMessageOutputSink(ILogger<SynchronousFileMachineMessageOutputSink> logger,
            IHumanOutput humanOutput,
            IMachineMessageJsonReserializer machineMessageJsonReserializer,
            FileStream fileStream)
        {
            this.Logger = logger;

            this.HumanOutput = humanOutput;
            this.MachineMessageJsonReserializer = machineMessageJsonReserializer;

            this.FileStream = fileStream;
        }

        public void Dispose()
        {
            // Do nothing. Let the creator (thus owner) of the output stream handle its disposal.

            GC.SuppressFinalize(this);
        }

        public void Write(IMachineMessage message)
        {
            // Serialize the message to a JObject.
            var jsonObjectSerialization = this.MachineMessageJsonReserializer.Serialize(message);
            if (!jsonObjectSerialization.Success)
            {
                // Note the failure to serialize.
                var errorMessage = $"{message.GetType().FullName}: Unable to serialize message to JSON.";

                // Tell a human.
                this.HumanOutput.Write(errorMessage);

                // Log as an error.
                this.Logger.LogError(errorMessage);
            }

            var jsonObject = jsonObjectSerialization.Result;

            // Serialize the JObject to text.
            var jsonSerializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
            };

            this.FileStream.Position = this.FileStream.Length - 1;

            using var textWriter = StreamWriterHelper.NewLeaveOpen(this.FileStream);

            textWriter.WriteLine();

            jsonSerializer.Serialize(textWriter, jsonObject);

            textWriter.WriteLine();
            textWriter.Write("]");

            this.FileStream.Flush(); // Synchronous, so immediately flush.

            // The JSON file format will contain a JSON array of objects, thus to "append" to the end of the array, we will need to either keep the file open, or seek in the file to just before the closing brace of the JSON file. 
        }
    }
}
