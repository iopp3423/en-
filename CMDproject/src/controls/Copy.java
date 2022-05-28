package controls;

import models.RouteLocation;
import utility.dataProcessing;
import views.PrintLocation;

public class Copy {

	private RouteLocation location;
	private PrintLocation print;
	private dataProcessing data;
		
	public Copy(RouteLocation location, PrintLocation print, dataProcessing data) {
		this.location = location;
		this.print = print;
		this.data = data;
	}
	
	public void copyController(String inputCommand) {
		
	}
	
}
