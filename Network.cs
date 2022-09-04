using System;
using System.Collections.Generic;
using System.Linq;

namespace BennerTesteLogica
{
    public class Network
    {
        private Elemento[] _elementos;
        public Network(long numeroElementos)
        {
            if (numeroElementos < 2)
            {
                throw new Exception("A classe network deve conter pelo menos 2 elementos.");
            }

            _elementos = new Elemento[numeroElementos];

            for (int indice = 1; indice <= _elementos.Length; indice++)
            {
                _elementos[indice - 1] = new Elemento(indice);
            }
        }

        public void Connect(long elementoA, long elementoB)
        {
            VerificarElementosMaiorQueZero(elementoA, elementoB);
            VerificarExistenciaElementos(elementoA, elementoB);

            if (elementoA == elementoB)
            {
                return;
            }

            if (!_elementos.First(E => E.ID == elementoA)._conexoes.Contains(elementoB))
            {
                _elementos.First(E => E.ID == elementoA)._conexoes.Add(elementoB);
                _elementos.First(E => E.ID == elementoB)._conexoes.Add(elementoA);
            }
        }

        public bool Query(long elementoA, long elementoB)
        {
            VerificarElementosMaiorQueZero(elementoA, elementoB);
            VerificarExistenciaElementos(elementoA, elementoB);

            if (elementoA == elementoB)
            {
                return true;
            }

            return VerificarConexaoElementos(elementoA, elementoB, new List<long> { elementoA});
        }

        private bool VerificarConexaoElementos(long elementoA, long elementoB, List<long> elementosVerificados)
        {
            if(_elementos.First(E => E.ID == elementoA)._conexoes.Any(C => C == elementoB))
            {
                return true;
            }

            foreach(long elementoConexao in _elementos.First(E => E.ID == elementoA)._conexoes)
            {
                if (!elementosVerificados.Contains(elementoConexao))
                {
                    elementosVerificados.Add(elementoConexao);
                    if (VerificarConexaoElementos(elementoConexao, elementoB, elementosVerificados))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void VerificarExistenciaElementos(long elementoA, long elementoB)
        {
            if (!_elementos.Any(E => E.ID == elementoA))
            {
                throw new Exception($"O elemento {elementoA} não existe no conjunto de elementos.");
            }
            if (!_elementos.Any(E => E.ID == elementoB))
            {
                throw new Exception($"O elemento {elementoB} não existe no conjunto de elementos.");
            }
        }

        private void VerificarElementosMaiorQueZero(long elementoA, long elementoB)
        {
            if (elementoA < 1 || elementoB < 1)
            {
                throw new Exception($"Nenhum elemento pode ser menor que 1.");
            }
        }

        protected struct Elemento
        {
            private long _id;
            public List<long> _conexoes { get; }
            public long ID { get => _id; }

            

            public Elemento(long id)
            {
                this._id = id;
                _conexoes = new List<long>();
            }
        }
    }
}
