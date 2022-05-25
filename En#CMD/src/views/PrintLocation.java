package views;

public class PrintLocation {

	public void printCurrentLocation(String location, String errorMessage, boolean is_Not_Error)
	{
		if(is_Not_Error) {
			System.out.printf(location);
		}
		else if(!is_Not_Error) {
			System.out.println(errorMessage);
			System.out.printf(location);
		}
	}
}
