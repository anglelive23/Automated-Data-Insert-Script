using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedDataInsert
{

    public class Worker
    {    
        
        public Worker()
        {
            AutomatedDataInsert();
        }

        void AutomatedDataInsert()
        {
            PopulateAllLevelsWithoutLevelOne();
            PupulateAllLevelsIncludingLevelOne();
        }



        private static void PopulateAllLevelsWithoutLevelOne()
        {
            int initialPressure = 950;
            int altitude = 470;
            int initialAltitude = 470;
            int levelThreeFractionFromLevelTwo = 1000;
            int levelFourInitialAltitudeValue = 2516;
            int altitudeFraction = 43;
            int iterationIndex = 1;

            Console.WriteLine("Pressure\tAltitude\tLevel");

            while (initialPressure >= 950 && initialPressure <= 980)
            {
                for (int i = 2; i <= 4; i++)
                {
                    Console.WriteLine($"{initialPressure}\t\t{altitude}\t\t{i}");

                    altitude = i switch
                    {
                        2 => (altitude + levelThreeFractionFromLevelTwo),
                        3 => (levelFourInitialAltitudeValue += 36),
                        _ => (altitude + 0),
                    };
                }
                initialPressure += 5;
                altitude = initialAltitude + (altitudeFraction * iterationIndex++);
            }
        }

        private static void PupulateAllLevelsIncludingLevelOne()
        {
            int pressure = 985;
            int altitude = 0;
            int initialAltitude = 0;
            int firstAltitudeFraction = 36;
            int altitudeFraction = 43;
            int levelTwoInitialAltitudeValue = 771;
            int levelTwoFractionFromLevelOne = 778;
            int levelThreeFractionFromLevelTwo = 1000;
            int levelFourInitialAltitudeValue = 2768;
            int iterationIndex = 1;

            while (pressure <= 1080)
            {
                for (int i = 1; i <= 4; i++)
                {
                    Console.WriteLine($"{pressure}\t\t{altitude}\t\t{i}");

                    altitude = i switch
                    {
                        1 => (pressure == 985) ? levelTwoInitialAltitudeValue : (altitude + levelTwoFractionFromLevelOne),
                        2 => (altitude + levelThreeFractionFromLevelTwo),
                        3 => (levelFourInitialAltitudeValue += firstAltitudeFraction),
                        _ => (altitude + 0),
                    };
                }
                altitude = (pressure == 985) ? (initialAltitude + firstAltitudeFraction) : ((initialAltitude + firstAltitudeFraction) + (altitudeFraction * iterationIndex++));
                pressure += 5;
            }
        }
    }
}
