using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.DirectSound;
using System.IO;
namespace Tank
{
    class Sound
    {
        private SecondaryBuffer secBuffer;
        public SecondaryBuffer SecBuffer
        {
            get { return secBuffer; }
            set { secBuffer = value; }
        }
        public Sound(Stream fileName)
        {
            BufferDescription desc = new BufferDescription();
            desc.StaticBuffer = true;
            Device dev=new Device();
           dev.SetCooperativeLevel(StartForm.Instance,CooperativeLevel.Normal);
           secBuffer = new SecondaryBuffer(fileName, desc, dev);
        }

        public void Play()
        {
            secBuffer.Play(0, BufferPlayFlags.Default);
        }
        
    }
}
