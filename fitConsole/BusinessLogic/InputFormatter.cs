using System;
using System.Text.RegularExpressions;

namespace Fit.BusinessLogic
{
	public class InputFormatter
	{
        private int _a;
        private int _b;

		public int a
		{
			get => _a;
			private set => _a = value;
		}

        public int b
        {
            get => _b;
            private set => _b = value;
        }

        public List<int> pipeSegments;

		public InputFormatter(string input)
		{
			// remove whitespaces
			input = Regex.Replace(input, @"\s+", "");

			// split input string into parcel and pipe dimensions
			List<int> allDimensions = input.Split(',').Select(int.Parse).ToList();
			if (!dimensionsValid(allDimensions))
			{
				throw new FormatException("Invalid dimensions");
			}
			this._a = allDimensions[0];
			this._b = allDimensions[1];
			if (_a > _b) (_a, _b) = (_b, _a);
			pipeSegments = allDimensions.GetRange(2, allDimensions.Count - 2);
        }


        public bool dimensionsValid(List<int> dims)
		{
			bool ret = true;
            // must always contain parcel width, height and 1 pipe diameter
            if (dims.Count < 3) 
				ret = false;

			foreach(int i in dims)
			{
				if (i <= 0)
				{
					ret = false;
					break;
				}
			}
			return ret;
		}
	}
}

