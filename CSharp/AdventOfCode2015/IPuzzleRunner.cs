namespace AdventOfCode2015
{
    public interface IPuzzleRunner
    {
        void SolveInRange(int startDay, int endDay);
        void SolveThisDay(int dayIndex);
        void SolveFromDay(int dayIndex);
        void SolveAll();
    }
}