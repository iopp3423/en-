package View;

import java.awt.Container;
import java.awt.Dimension;
import javax.swing.JFrame;

public class PrintCalculator extends JFrame{

	
	private Container frame; // 프레임 

	
	public void GetCalculator()
	{
		frame();
		panel();
	}
	
	private void frame()
	{
		setSize(840, 840/12*9);
		setResizable(false); // 창 크기 조절 불가
		setPreferredSize(new Dimension(840, 840/12*9));	
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		setLocationRelativeTo(null); // 화면 나오는 위치
		setVisible(true);
	}
	
	private void panel()
	{
		frame = getContentPane();
		
	}
	
	
}
