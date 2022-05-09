package use;


import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Graphics;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemListener;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.awt.event.ItemEvent;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.JTextField;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import javax.imageio.ImageIO;



public class Screen {
	
	public JFrame frame;
	ImageIcon [] imageIcon = new ImageIcon[30];
	JButton [] imageButton = new JButton[30];
	
	public Screen() {
		initialize();
	}
	
	public void initialize()
	{
		
		
		frame = new JFrame(); // 프레임 생성

		frame.setSize(840, 840/12*9);
		frame.setResizable(false); // 창 크기 조절 불가
		frame.setPreferredSize(new Dimension(840, 840/12*9));	
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // 프로그램 실행 후 종료
		frame.setLocationRelativeTo(null); // 화면 나오는 위치
		
		
		JPanel FirstPanel = new JPanel();
		JPanel SearchPanel = new JPanel(new BorderLayout(100, 100));
		JPanel RecordPanel = new JPanel();
		JPanel Grid = new JPanel(new GridLayout(5,6));
		JPanel center = new JPanel(new BorderLayout());
		JPanel collectPanel = new JPanel(new FlowLayout());
		
		center.add(Grid);	
		
		FirstPanel.setLayout(null);
		
		frame.getContentPane().add(FirstPanel);	
					
		
		///////////////////////////////////////검색 패널 
		String[] Choose = {"10", "20","30"};
		JButton Secondsearch = new JButton("검색하기");
		JButton back = new JButton("뒤로가기");
		JTextField SecondInput = new JTextField(15);
		JComboBox comboBox = new JComboBox(Choose);
		
		Secondsearch.setBounds(500, 50, 100, 40); // 버튼위치
		back.setBounds(600, 50, 100, 40); // 
		SecondInput.setBounds(200,50, 300, 40); // 버튼위치 수
		comboBox.setBounds(700,50, 70, 40);
		
		
		collectPanel.add(SecondInput); // 입력창 
		collectPanel.add(Secondsearch); // 검색버튼 
		collectPanel.add(back);// 뒤로가기 버튼 
		collectPanel.add(comboBox);
		SearchPanel.add(collectPanel,BorderLayout.NORTH);

		
			
		comboBox.addItemListener(new ItemListener() {

			public void itemStateChanged(ItemEvent e) {

				JComboBox cb = (JComboBox) e.getSource(); //콤보박스 알아내기 

				int index = cb.getSelectedIndex();
							
			}
			

		});

					
		
		back.addActionListener(new ActionListener(){ // 뒤로가기 
			public void actionPerformed(ActionEvent e) {
				
				SearchPanel.setVisible(false);
				frame.getContentPane().removeAll();
				frame.getContentPane().add(FirstPanel);	
				FirstPanel.setVisible(true);
			}
				
		});
		
		
		////////////////////////처음화면 
		JButton Firstsearch = new JButton("검색하기");
		JButton record = new JButton("기록보기");		
		JTextField Input = new JTextField(10);
		   
        
				
		Firstsearch.setBounds(500, 50, 100, 40); // 버튼위치
		record.setBounds(600, 50, 100, 40); // 
		Input.setBounds(200, 50, 300, 40); // 버튼위치 수d
		
		FirstPanel.add(Input);
		FirstPanel.add(Firstsearch);
		FirstPanel.add(record);
		
		Firstsearch.addActionListener(new ActionListener(){ // 검색하기 
			public void actionPerformed(ActionEvent e) {

				
				FirstPanel.setVisible(false);
				frame.getContentPane().removeAll();
				imageIcon = ImagePrint("30",Input.getText()); // 파일 받아오기
				
				for(int index = 0; index<30;index++)
				{
					imageButton[index] = new JButton(new ImageIcon(imageIcon[index].getImage().getScaledInstance(120, 80, Image.SCALE_SMOOTH)));
					//imageButton[index].setPreferredSize(new Dimension(30, 30));
					
					Grid.setSize(300, 200);
					Grid.add(imageButton[index]);				
				}
				
				SearchPanel.add(Grid, BorderLayout.CENTER);
				frame.getContentPane().add(SearchPanel);
				SearchPanel.setVisible(true);
							
			}
				
		});
		
		record.addActionListener(new ActionListener(){ // 기록보기 
			public void actionPerformed(ActionEvent e) {

				FirstPanel.setVisible(false);
				frame.getContentPane().removeAll();
				frame.getContentPane().add(RecordPanel);
				System.out.println(Input.getText());
				RecordPanel.setVisible(true);
				
				
			}
				
		});
		
	}
        

		///// 기록 보기
		/*
		JButton search = new JButton("검색하기");
		JButton back = new JButton("뒤로가기");
		JPanel button = new JPanel();
		JPanel panel = new JPanel();
		JLabel title = new JLabel("로그 기록");
		title.setSize(150, 150);
		*/
		//JTextField Input = new JTextField(10);
		
		
		
		//button.add(search);
		//button.add(back);
		//panel.add(title);
		//panel.add(button);
		
		//frame.add(panel);
		
		
		//back.addActionListener(new ActionListener(){
			//public void actionPerformed(ActionEvent e) {
				
				//frame.setVisible(false);
			//}
				
		//});
		
		
		
		public ImageIcon[] ImagePrint(String size, String name)
		{					
		    String temp;
			String BASE_URL = "https://dapi.kakao.com/v2/search/image?sort=accuracy&page=1&size="+ size + "&query=" + name;
			JSONObject result = null;
			URL url = null;
			URL link = null;
			Image image;
			ImageIcon [] imageicon = new ImageIcon[30];
			
			HttpURLConnection con= null;
			StringBuilder sb = new StringBuilder();
			try {
				// URL 객채 생성 (BASE_URL)
				url = new URL(BASE_URL);
				// URL을 참조하는 객체를 URLConnection 객체로 변환
				con = (HttpURLConnection) url.openConnection();

				// 커넥션 request 방식 "GET"으로 설정
				con.setRequestMethod("GET");

				// 커넥션 request 값 설정(key,value) 
				con.setRequestProperty("Content-type", "application/json");
				// void setRequestProperty (key,value) 다른 예시
				 con.setRequestProperty("Authorization", "KakaoAK 26a41b7bfe87ed292acb3bbb3f064df6");
				// con.setRequestProperty("X-Auth-Token", AUTH_TOKEN);
				// 받아온 JSON 데이터 출력 가능 상태로 변경 (default : false)
				con.setDoOutput(true);

				// 데이터 입력 스트림에 담기
				BufferedReader br = new BufferedReader(new InputStreamReader(con.getInputStream(), "UTF-8"));
				while(br.ready()) {
					sb.append(br.readLine());					
				}
		
				con.disconnect();
			}catch(Exception e) {
				e.printStackTrace();
			}
			
					
				try {
					result = (JSONObject) new JSONParser().parse(sb.toString());
				} catch (ParseException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				
				StringBuilder out = new StringBuilder();
				out.append(result.get("status") +" : " + result.get("status_message") +"\n");
					
		
				
				// JSONObject에서 Array데이터를 get하여 JSONArray에 저장한다.
				JSONArray array = (JSONArray) result.get("documents");

					
				out.append("데이터 출력하기 \n");
				
				for(int i=0; i<array.size(); i++) {		
					JSONObject arr = (JSONObject)array.get(i);
					//System.out.println(arr.get("image_url"));
									
					try {
						link = new URL(arr.get("image_url").toString());
					} catch (MalformedURLException e1) {
						// TODO Auto-generated catch block
						e1.printStackTrace();
					}			
					try {
						image = ImageIO.read(link); // 이미지로 저장 
						imageicon[i] = new ImageIcon(image);
						
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
					
					
				}		
				return imageicon;

		           
				
		}
			
}
