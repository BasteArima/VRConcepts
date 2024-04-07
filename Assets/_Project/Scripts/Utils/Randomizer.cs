public static class Randomizer
{
    private const float FULL_CHANCE = 100.0f;
    public static bool IsEventHappen(float chance)
    {
        float randomValue = UnityEngine.Random.value;
        float randomChance = randomValue * FULL_CHANCE;
        return chance <= randomChance;
    }
}

