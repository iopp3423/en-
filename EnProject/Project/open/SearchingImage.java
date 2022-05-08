package open;
import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JComponent;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;


import java.io.IOException;
import java.io.PrintWriter;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.io.FileReader;

public class SearchingImage {

	public SearchingImage()
	{
		JFrame  frame = new JFrame(); // 프레임 생성 
		JButton search = new JButton("검색하기");
		JButton back = new JButton("뒤로가기");
		JPanel button = new JPanel();
		JPanel panel = new JPanel();
		JTextField Input = new JTextField(10);
		
		
		button.add(search);
		button.add(back);
		panel.add(Input);
		panel.add(button);
		
		
		back.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {
				
				frame.setVisible(false);
			}
				
		});
		
		frame.add(panel);
		frame.setResizable(false); // 창 크기 조절 불가
		frame.setVisible(true); //창 뜨게하기 
		frame.setPreferredSize(new Dimension(840, 840/12*9));
		frame.setSize(840, 840/12*9);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치  
	}
	
	
	
	
	/*
	public void SearchImage()
	{
		String query = "page:2, size:30, sort:accracy";
		URL url = new URL("https://dapi.kakao.com/v2/search/image?" + query);
		String headers = "Authorization : KakaoAK 26a41b7bfe87ed292acb3bbb3f064df6";
		HttpURLConnection conn = (HttpURLConnection)url.openConnection();

		

		conn.setRequestMethod("GET");
		conn.setRequestProperty("Content-Type", "application/json"); // Content-Type 지정
		conn.setDoOutput(true); // 출력 가능 상태로 변경
		conn.connect();
					    
		// 데이터  읽어오기
		BufferedReader br = new BufferedReader(new InputStreamReader(conn.getInputStream(), "UTF-8"));
		StringBuilder sb = new StringBuilder();
		String line = "";
		while((line = br.readLine()) != null) {
			sb.append(line); // StringBuilder 사용시 객체를 계속 생성하지 않고 하나의 객체릂 수정하므로 더 빠름.
		}
		conn.disconnect();

		// JSON Parsing
		JSONObject jsonObj = (JSONObject) new JSONParser().parse(sb.toString());

		jsonObj.get("name"); // 이런 방식으로 데이터 꺼낼 수 있음.
	}
	*/
}
