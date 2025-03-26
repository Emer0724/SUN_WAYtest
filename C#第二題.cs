public string ChangeCreditNum(string nums)
{
    string result = "";
    List<string> elements = nums.Select(e => e.ToString()).ToList();
    if (!nums.All(char.IsDigit))
    {
        result = "請輸入數字";
        return result;
    }

    if (elements.Count() < 16)
    {
        result = "請輸入16位數字";
        return result;
    }

    for (int x = 0; x < elements.Count() - 4; x++)
    {
        if ((x + 1) % 4 == 0)  
        {
            elements[x] = "*-";

        }
        else
        {
            elements[x] = "*";
        }
    }

    result = result = string.Join("", elements);

    return result;
}