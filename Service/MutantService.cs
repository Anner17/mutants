using Mutantes.Domain;
using Mutantes.Models;
using Mutantes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mutantes.Service
{
    public class MutantService
    {
        DnaRepository repository = new DnaRepository();

        public bool CheckDna(List<string> data)
        {
            string fullDna = "";
            foreach(string s in data)
            {
                fullDna += s;
            }

            Dna dna = repository.findByDna(fullDna);

            if(dna != null)
            {
                return dna.isMutant;
            }

            dna = new Dna(){ dna=fullDna, isMutant = Analysis(data)};

            repository.save(dna);

            return dna.isMutant;
        }

        public Statistics getStatistics()
        {
            Statistics statistics = new Statistics();
            List<Dna> list = repository.findAll();
            statistics.Mutants = list.Where(x => x.isMutant).Count();
            statistics.NormalPeople = list.Where(x => !x.isMutant).Count();
            return statistics;
        }

        private bool Analysis(List<string> dna)
        {
            int counter = 0;
            //diagonal1
            for (int i = 1; i < dna.Count; i++)
            {
                if (dna[i][i] == dna[i - 1][i - 1])
                {
                    counter++;
                    if (counter == 3)
                    {
                        return true;
                    }
                }
                else
                {
                    counter = 0;
                }
            }

            counter = 0;

            //diagonal2
            for (int i = 1; i < dna.Count; i++)
            {
                if (dna[i][dna.Count - i - 1] == dna[i - 1][dna.Count - i])
                {
                    counter++;
                    if (counter == 3)
                    {
                        return true;
                    }
                }
                else
                {
                    counter = 0;
                }
            }


            counter = 0;
            //vertical
            for (int i = 0; i < dna.Count; i++)
            {
                for (int j = 1; j < dna.Count; j++)
                {
                    if (dna[j][i] == dna[j - 1][i])
                    {
                        counter++;
                        if (counter == 3)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        counter = 0;
                    }
                }
                counter = 0;
            }

            counter = 0;
            //horizontal
            for (int i = 0; i < dna.Count; i++)
            {
                for (int j = 1; j < dna.Count; j++)
                {
                    if (dna[i][j] == dna[i][j - 1])
                    {
                        counter++;
                        if (counter == 3)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        counter = 0;
                    }
                }
                counter = 0;
            }

            return false;
        }
    }
}
