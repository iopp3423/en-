package utility;

import java.util.Scanner;

public class InputCommand {
	private Scanner scan;

	public InputCommand() {
		scan = new Scanner(System.in);
	}
	
	public String inputInstruction() {
		String instruction = scan.nextLine();	
		
		return instruction;
	}
}