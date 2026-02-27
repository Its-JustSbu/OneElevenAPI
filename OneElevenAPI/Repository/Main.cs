namespace OneElevenAPI.Repository
{
    public class Main
    {
        public char[] sortString(char[] data)
        {
            if (data.Length == 0) return [];

            if (data.Length == 1) return data;

            var Midpoint = data.Length / 2;
            var arr1 = data[0..Midpoint];
            var arr2 = data[Midpoint..data.Length];

            return mergeArr(sortString(arr1), sortString(arr2));
        }

        private static char[] mergeArr(char[] arr1, char[] arr2)
        {
            if (arr1.Length == 0 && arr2.Length == 0) return [];

            var combinedArr = new char[arr1.Length + arr2.Length];
            var index = 0;

            var arr1Index = 0;
            var arr2Index = 0;

            try
            {
                while (arr1.Length > arr1Index || arr2.Length > arr2Index)
                {
                    if (arr1.Length > arr1Index)
                    {
                        while (!Char.IsLetter(arr1[arr1Index]))
                        {
                            arr1Index++;
                            goto invalidChar;
                        }

                        if (arr2.Length > arr2Index)
                        {
                            while (!Char.IsLetter(arr2[arr2Index]))
                            {
                                arr2Index++;
                                goto invalidChar;
                            }

                            if (Char.ToLower(arr1[arr1Index]) <= Char.ToLower(arr2[arr2Index]))
                            {
                                combinedArr[index++] = arr1[arr1Index++];
                            }
                            else
                            {
                                combinedArr[index++] = arr2[arr2Index++];
                            }
                        }
                        else
                        {
                            while (!Char.IsLetter(arr1[arr1Index]))
                            {
                                arr1Index++;
                                goto invalidChar;
                            }

                            combinedArr[index++] = arr1[arr1Index++];
                        }
                    }
                    else
                    {
                        while (!Char.IsLetter(arr2[arr2Index]))
                        {
                            arr2Index++;
                            goto invalidChar;
                        }

                        combinedArr[index++] = arr2[arr2Index++];
                    }
                invalidChar:;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return combinedArr[0..index];
        }
    }
}
