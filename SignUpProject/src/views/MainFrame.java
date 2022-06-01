package views;

import java.awt.Dimension;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import utility.Constants;

public class MainFrame extends JFrame{
	
	public MainPanel mainPanel;
	
	public MainFrame()
	{
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/사진1.png"));
		MainPanel panel = new MainPanel(new ImageIcon(imageIcon.getImage().getScaledInstance(1280, 720, Image.SCALE_SMOOTH)).getImage());
		add(panel);
		
		
		setSize(Constants.SCREEN_SIZE_WIDTH,Constants.SCREEN_SIZE_HEIGHT);
		setPreferredSize(new Dimension(Constants.SCREEN_SIZE_WIDTH, Constants.SCREEN_SIZE_HEIGHT));	
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		setLocationRelativeTo(null); // 화면 나오는 위치
		setVisible(true);
		pack();
	}
	
}
