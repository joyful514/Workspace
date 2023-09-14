package main

import (
	"C"
	"crypto/tls"
	"fmt"
	"log"
	"net"
	"net/smtp"
)

//export Test

// Dial return a smtp client
func Dial(addr string) (*smtp.Client, error) {
	conn, err := tls.Dial("tcp", addr, nil)
	if err != nil {
		log.Println("tls.Dial Error:", err)
		return nil, err
	}

	host, _, _ := net.SplitHostPort(addr)
	return smtp.NewClient(conn, host)
}

// SendMailWithTLS send email with tls
func SendMailWithTLS(addr string, auth smtp.Auth, from string,
	to []string, msg []byte) (err error) {
	//create smtp client
	c, err := Dial(addr)
	if err != nil {
		log.Println("Create smtp client error:", err)
		return err
	}
	defer c.Close()
	if auth != nil {
		if ok, _ := c.Extension("AUTH"); ok {
			if err = c.Auth(auth); err != nil {
				log.Println("Error during AUTH", err)
				return err
			}
		}
	}
	if err = c.Mail(from); err != nil {
		return err
	}
	for _, addr := range to {
		if err = c.Rcpt(addr); err != nil {
			return err
		}
	}
	w, err := c.Data()
	if err != nil {
		return err
	}
	_, err = w.Write(msg)
	if err != nil {
		return err
	}
	err = w.Close()
	if err != nil {
		return err
	}
	return c.Quit()
}

//export sendMailUsingGo1
func sendMailUsingGo1(host *C.char, flag bool) *C.char {
	goHost := "host:" + C.GoString(host)
	fmt.Println(goHost)
	fmt.Println(flag)
	return C.CString(goHost)
}

func Test465() error {
	host := "smtp.qcloudmail.com"
	port := 465
	//控制台创建的发信地址
	email := "xi@upep.xyz"
	//控制台设置的SMTP密码
	password := "Aq250jhKUj3951"
	toEmail := "706518747@qq.com"
	header := make(map[string]string)
	header["From"] = "test " + "<" + email + ">"
	header["To"] = toEmail
	header["Subject"] = "test subject"
	//html格式邮件
	header["Content-Type"] = "text/html; charset=UTF-8"
	body := "<!DOCTYPE html>\n<html>\n<head>\n<meta charset=\"utf-8\">\n<title>hello world</title>\n</head>\n<body>\n " +
		"<h1>我的第一个标题</h1>\n    <p>我的第一个段落。</p>\n</body>\n</html>"
	//纯文本格式邮件
	//header["Content-Type"] = "text/plain; charset=UTF-8"
	//body := "test body"
	message := ""
	for k, v := range header {
		message += fmt.Sprintf("%s: %s\r\n", k, v)
	}
	message += "\r\n" + body
	auth := smtp.PlainAuth(
		"",
		email,
		password,
		host,
	)
	err := SendMailWithTLS(
		fmt.Sprintf("%s:%d", host, port),
		auth,
		email,
		[]string{toEmail},
		[]byte(message),
	)
	if err != nil {
		fmt.Println("Send email error:", err)
	} else {
		fmt.Println("Send mail success!")
	}
	return err
}

//export sendMailUsingGo
func sendMailUsingGo(_from *C.char, _to *C.char, _reply *C.char, _subject *C.char,
	_body *C.char, _host *C.char, _port int, _user *C.char, _pwd *C.char) *C.char {

	host := C.GoString(_host)
	port := _port
	//控制台创建的发信地址
	email := C.GoString(_user)
	fmt.Println("email:" + email)
	//控制台设置的SMTP密码
	password := C.GoString(_pwd)
	fmt.Println("password:" + password)
	toEmail := C.GoString(_to)
	header := make(map[string]string)
	header["From"] = "test " + "<" + email + ">"
	header["To"] = C.GoString(_to)
	header["Subject"] = C.GoString(_subject)
	//html格式邮件
	header["Content-Type"] = "text/html; charset=UTF-8"
	header["Reply-To"] = C.GoString(_reply)
	body := C.GoString(_body)
	//纯文本格式邮件
	//header["Content-Type"] = "text/plain; charset=UTF-8"
	//body := "test body"
	message := ""
	for k, v := range header {
		message += fmt.Sprintf("%s: %s\r\n", k, v)
	}
	message += "\r\n" + body
	auth := smtp.PlainAuth(
		"",
		email,
		password,
		host,
	)
	err := SendMailWithTLS(
		fmt.Sprintf("%s:%d", host, port),
		auth,
		email,
		[]string{toEmail},
		[]byte(message),
	)
	if err != nil {
		fmt.Println("Send email error:", err)
		return C.CString(fmt.Sprintf("%s", err.Error()))

	} else {
		fmt.Println("Send mail success!")
		return C.CString("")
	}
}

func main() {
	Test465()
}

//export test1
func test1() {

}
