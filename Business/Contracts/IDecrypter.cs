using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IDecrypter
    {
        string Decrypt(string cipherText);
    }
}
