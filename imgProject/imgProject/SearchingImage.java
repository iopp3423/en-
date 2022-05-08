package imgProject;

import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.JTextField;

public class SearchingImage {
	
	JFrame frame;
	
	JPanel panel = new JPanel();

	JTextField  InputSearch = new JTextField(10); // 검색어 입
	
	JButton searchButton = new JButton("검색하기"); // 버튼생김 
	JButton back = new JButton("뒤로가기");// 버튼생김 
	
	JLabel label = new JLabel(); // 글자 넣게해줌? 
	JTextArea textArea = new JTextArea();
	JPanel btnPanel = new JPanel();
	
	
	public void SearchImage(String input)
	{
		panel.add(InputSearch);
		panel.add(searchButton);
		panel.add(back);
		System.out.println(input);
		
		
		frame.add(panel);
		
		frame.setLayout(null);
		frame.setResizable(false); // 창 크기 조절 불가 true 가능 
		frame.setVisible(true); // 창 보이게 해줌 false는 안보임 
		frame.setPreferredSize(new Dimension(840, 840/12*9)); // 창 크기 조절
		frame.setSize(840, 840/12*9); // 윗줄이랑 세트
		frame.setLocationRelativeTo(null); // 화면 가운데 출
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 종료 시 이거 있어야 종료
	}
	
	
}