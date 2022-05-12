package model;

public class CalculationData {

	
	public int CalculatePlue(int Left, int Right) // 나중에 소수점 까지 생각해서 자료형 바꿔야
	{
		int result = Left+Right;
		return result;
	}
	public int CalculateMinus(int Left, int Right) // 뺴기 
	{
		int result = Left-Right;
		return result;
	}
	public int CalculateDivision(int Left, int Right) // 나누기 
	{
		int result = Left/Right;
		return result;
	}
	public int CalculateMultifly(int Left, int Right) // 곱하기 
	{
		int result = Left*Right;
		return result;
	}
}
