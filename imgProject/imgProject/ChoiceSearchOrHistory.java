package imgProject;

import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.JTextField;


public class ChoiceSearchOrHistory {
	SearchingImage search = new SearchingImage();
	JFrame frame = new JFrame();  
	JPanel panel = new JPanel(); // 프레임 안에 여러 개의 요소를 넣을 수 있게 해줌
	JPanel Search = new JPanel();
	JPanel History = new JPanel();
	JTextField  InputSearch = new JTextField(10); // 검색어 입
	
	JButton searchButton = new JButton("검색하기"); // 버튼생김 
	JButton historyButton = new JButton("기록보기");// 버튼생김 
	
	JLabel label = new JLabel(); // 글자 넣게해줌? 
	JTextArea textArea = new JTextArea();
	JPanel btnPanel = new JPanel();
	


	public void frame()
	{			
		//btnPanel.add(searchButton); // 검색하기 버튼 
		//btnPanel.add(historyButton); // 뒤로가기 버튼
		InputSearch.setLayout(null);
		Search.setLayout(null); // 패널 레이아웃 설정 
		History.setLayout(null); // 패널 레이아웃 설정
		InputSearch.setBounds(230, 100, 250, 50);
		Search.setBounds(450,50, 300, 100);
		History.setBounds(550,50, 400, 200);
 		
		historyButton.setBounds(70, 50, 100, 50); // 컴포넌트 위치 크기 설정 
		searchButton.setBounds(70, 50, 100, 50);// 컴포넌트 위치 크기 설정 
		
		Search.add(searchButton); // 패널에 삽입 
		History.add(historyButton); // 패널에 삽입 
		
		
		//panel.add(new JLabel("Hello world")); //Label을 통해 내용 넣어줌
		
		searchButton.addActionListener(new ActionListener()
		{
			@Override
			public void actionPerformed(ActionEvent e) { // actionPerformed 를 통해 버튼 클릭 시 행동 취할 수 있
				search.SearchImage(InputSearch.getText());
			}
		});
		
		
		frame.add(InputSearch);
		frame.add(Search); // 프레임 객체 안에 페널을 넣어줘야지 적용이 된다.
		frame.add(History);
		
		
		frame.setLayout(null);
		frame.setResizable(false); // 창 크기 조절 불가 true 가능 
		frame.setVisible(true); // 창 보이게 해줌 false는 안보임 
		frame.setPreferredSize(new Dimension(840, 840/12*9)); // 창 크기 조절
		frame.setSize(840, 840/12*9); // 윗줄이랑 세트
		frame.setLocationRelativeTo(null); // 화면 가운데 출
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 종료 시 이거 있어야 종료
		
	}

}
