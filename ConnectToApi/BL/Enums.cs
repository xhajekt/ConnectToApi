using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectToApi.BL
{
    public class Enums
    {
        public enum FaceDetectorResourceId
        {
            cpu, gpu, accurate_cpu, accurate_gpu
        }

        public enum TemplateGeneratorResourceId
        {
            cpu, gpu
        }
    }
}
