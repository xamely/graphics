#include <C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\include\GL\glut.h>
#include <C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\include\GL\freeglut.h>
#include <C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\include\GL\SOIL.h>

int w, h; //reshape window
int w_car = 100, l_car = 60; //car size
float rotate_x, rotate_y, rotate_z;
float p_x, p_z;
bool flags[] = { false, false, false, false, false };
GLuint texture_road, texture_car, texture_window, texture_back_car;

void load_textures() {
	texture_road = SOIL_load_OGL_texture("C:\\Users\\mxeni\\OneDrive\\Рабочий стол\\OpenGL\\road.jpg", SOIL_LOAD_AUTO, SOIL_CREATE_NEW_ID, SOIL_FLAG_MIPMAPS | SOIL_FLAG_INVERT_Y | SOIL_FLAG_NTSC_SAFE_RGB | SOIL_FLAG_COMPRESS_TO_DXT);
	texture_car = SOIL_load_OGL_texture("C:\\Users\\mxeni\\OneDrive\\Рабочий стол\\OpenGL\\car.jpg", SOIL_LOAD_AUTO, SOIL_CREATE_NEW_ID, SOIL_FLAG_MIPMAPS | SOIL_FLAG_INVERT_Y | SOIL_FLAG_NTSC_SAFE_RGB | SOIL_FLAG_COMPRESS_TO_DXT);
	texture_window = SOIL_load_OGL_texture("C:\\Users\\mxeni\\OneDrive\\Рабочий стол\\OpenGL\\window.jpg", SOIL_LOAD_AUTO, SOIL_CREATE_NEW_ID, SOIL_FLAG_MIPMAPS | SOIL_FLAG_INVERT_Y | SOIL_FLAG_NTSC_SAFE_RGB | SOIL_FLAG_COMPRESS_TO_DXT);
	texture_back_car = SOIL_load_OGL_texture("C:\\Users\\mxeni\\OneDrive\\Рабочий стол\\OpenGL\\backcar.jpg", SOIL_LOAD_AUTO, SOIL_CREATE_NEW_ID, SOIL_FLAG_MIPMAPS | SOIL_FLAG_INVERT_Y | SOIL_FLAG_NTSC_SAFE_RGB | SOIL_FLAG_COMPRESS_TO_DXT);
}

void Init(void) {
	rotate_x = 0;
	rotate_y = 0;
	rotate_z = 0;
	p_x = -260;
	p_z = 120;
	glClearColor(0.3f, 0.5f, 0.5f, 1.0f);
	glLoadIdentity();

	load_textures();

	glLightModelf(GL_LIGHT_MODEL_TWO_SIDE, GL_TRUE);
	glEnable(GL_NORMALIZE);
}

void DrawRoad()
{
	glBindTexture(GL_TEXTURE_2D, texture_road); //create texture
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR); //texture parameters
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);

	glEnable(GL_TEXTURE_2D); //allow to use texture
	glBegin(GL_QUADS);
	glTexCoord2f(0.0, 0.0); glVertex3f(-300.0, 0.0, 0.0);
	glTexCoord2f(0.0, 1.0); glVertex3f(-300.0, 0.0, 300.0);
	glTexCoord2f(1.0, 1.0); glVertex3f(500.0, 0.0, 300.0);
	glTexCoord2f(1.0, 0.0); glVertex3f(500.0, 0.0, 0.0);
	glEnd();
	glDisable(GL_TEXTURE_2D);
}

void DrawCar()
{
	//wheels
	int r = 10;
	glColor3f(0.0, 0.0, 0.0);

	glPushMatrix();
	glTranslatef(p_x + r, r + 1, p_z + l_car);
	glutSolidTorus(3, r, 54, 54);
	glPopMatrix();

	glPushMatrix();
	glTranslatef(p_x + w_car - r, r + 1, p_z + l_car);
	glutSolidTorus(3, r, 54, 54);
	glPopMatrix();

	glPushMatrix();
	glTranslatef(p_x + w_car - r, r + 1, p_z);
	glutSolidTorus(3, r, 54, 54);
	glPopMatrix();

	glPushMatrix();
	glTranslatef(p_x + r, r + 1, p_z);
	glutSolidTorus(3, r, 54, 54);
	glPopMatrix();

	//bottom
	glBindTexture(GL_TEXTURE_2D, texture_car);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glEnable(GL_TEXTURE_2D);	
	glColor3f(0.40, 0.35, 0.35);
	int d = 12.;
	int h = 40.;

	glBegin(GL_QUAD_STRIP);
	glVertex3f(p_x, h, p_z);			glTexCoord2f(0, 0);
	glVertex3f(p_x + w_car, h, p_z);	glTexCoord2f(1, 0);

	glVertex3f(p_x, h, p_z + l_car);	glTexCoord2f(0, 1);
	glVertex3f(p_x + w_car, h, p_z + l_car); glTexCoord2f(1, 1);

	glVertex3f(p_x, d, p_z + l_car);	glTexCoord2f(0, 0);
	glVertex3f(p_x + w_car, d, p_z + l_car); glTexCoord2f(1, 0);

	glVertex3f(p_x, d, p_z);			glTexCoord2f(1, 1);
	glVertex3f(p_x + w_car, d, p_z);	glTexCoord2f(0, 1);

	glVertex3f(p_x, h, p_z);			glTexCoord2f(0, 0);
	glVertex3f(p_x + w_car, h, p_z);	glTexCoord2f(1, 0);
	glEnd();
	
	glBegin(GL_QUADS);
	glVertex3f(p_x, h, p_z);			glTexCoord2f(0, 1);
	glVertex3f(p_x, h, p_z + l_car);	glTexCoord2f(1, 1);
	glVertex3f(p_x, d, p_z + l_car);	glTexCoord2f(1, 0);
	glVertex3f(p_x, d, p_z);			glTexCoord2f(0, 0);
	glEnd();

	glBegin(GL_QUADS);
	glVertex3f(p_x + w_car, h, p_z);			glTexCoord2f(0, 1);
	glVertex3f(p_x + w_car, h, p_z + l_car);	glTexCoord2f(1, 1);
	glVertex3f(p_x + w_car, d, p_z + l_car);	glTexCoord2f(1, 0);
	glVertex3f(p_x + w_car, d, p_z);			glTexCoord2f(0, 0);
	glEnd();
	

	//cabin
	int h1 = 70.;
	glBegin(GL_QUAD_STRIP);
	glVertex3f(p_x + w_car - 30, h1, p_z);	glTexCoord2f(0, 0);
	glVertex3f(p_x + w_car, h1, p_z);		glTexCoord2f(1, 0);

	glVertex3f(p_x + w_car - 30,h1, p_z + l_car);	glTexCoord2f(1, 1);
	glVertex3f(p_x + w_car, h1, p_z + l_car);		glTexCoord2f(0, 1);

	glVertex3f(p_x + w_car - 30, h, p_z + l_car);	glTexCoord2f(0, 0);
	glVertex3f(p_x + w_car, h, p_z + l_car);		glTexCoord2f(1, 0);

	glVertex3f(p_x + w_car - 30, h, p_z);	glTexCoord2f(0, 1);
	glVertex3f(p_x + w_car, h, p_z);		glTexCoord2f(1, 1);

	glVertex3f(p_x + w_car - 30, h1, p_z);	glTexCoord2f(1, 0);
	glVertex3f(p_x + w_car, h1, p_z);		glTexCoord2f(0, 0);
	glEnd();

	glBegin(GL_QUADS);
	glVertex3f(p_x + w_car - 30, h1, p_z);			glTexCoord2f(0, 0);
	glVertex3f(p_x + w_car - 30, h1, p_z + l_car);	glTexCoord2f(1, 0);
	glVertex3f(p_x + w_car - 30, h, p_z + l_car);	glTexCoord2f(1, 1);
	glVertex3f(p_x + w_car - 30, h, p_z);			glTexCoord2f(0, 1);
	glEnd();

	glDisable(GL_TEXTURE_2D);

	glBindTexture(GL_TEXTURE_2D, texture_window);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glEnable(GL_TEXTURE_2D);
	glColor3f(0.55, 0.9, 0.9);

	glBegin(GL_QUADS);
	glVertex3f(p_x + w_car, h1, p_z);			glTexCoord2f(0, 0);
	glVertex3f(p_x + w_car, h1, p_z + l_car);	glTexCoord2f(1, 0);
	glVertex3f(p_x + w_car, h, p_z + l_car);	glTexCoord2f(1, 1);
	glVertex3f(p_x + w_car, h, p_z);			glTexCoord2f(0, 1);
	glEnd();

	glDisable(GL_TEXTURE_2D);

	//back of car
	int h2 = 100;

	glBindTexture(GL_TEXTURE_2D, texture_back_car);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glEnable(GL_TEXTURE_2D);
	glColor3f(0.55, 0.9, 0.9);

	glBegin(GL_QUADS);
	glVertex3f(p_x, h2, p_z);			glTexCoord2f(0, 0);
	glVertex3f(p_x, h2, p_z + l_car);	glTexCoord2f(1, 0);
	glVertex3f(p_x, h, p_z + l_car);	glTexCoord2f(1, 1);
	glVertex3f(p_x, h, p_z);			glTexCoord2f(0, 1);
	glEnd();

	glBegin(GL_QUADS);
	glVertex3f(p_x + w_car - 35, h2, p_z);			glTexCoord2f(0, 0);
	glVertex3f(p_x + w_car - 35, h2, p_z + l_car);	glTexCoord2f(1, 0);
	glVertex3f(p_x + w_car - 35, h, p_z + l_car);	glTexCoord2f(1, 1);
	glVertex3f(p_x + w_car - 35, h, p_z);			glTexCoord2f(0, 1);
	glEnd();

	glBegin(GL_QUADS);
	glVertex3f(p_x, h2, p_z);				glTexCoord2f(0, 0);
	glVertex3f(p_x + w_car - 35, h2, p_z);	glTexCoord2f(1, 0);
	glVertex3f(p_x + w_car - 35, h, p_z);	glTexCoord2f(1, 1);
	glVertex3f(p_x, h, p_z);				glTexCoord2f(0, 1);
	glEnd();

	glBegin(GL_QUADS);
	glVertex3f(p_x, h2, p_z + l_car);			glTexCoord2f(0, 0);
	glVertex3f(p_x + w_car - 35, h2, p_z + l_car);	glTexCoord2f(1, 0);
	glVertex3f(p_x + w_car - 35, h, p_z + l_car);	glTexCoord2f(1, 1);
	glVertex3f(p_x, h, p_z + l_car);			glTexCoord2f(0, 1);
	glEnd();

	glBegin(GL_QUADS);
	glVertex3f(p_x, h2, p_z);						glTexCoord2f(0, 0);
	glVertex3f(p_x + w_car - 35, h2, p_z);			glTexCoord2f(1, 0);
	glVertex3f(p_x + w_car - 35, h2, p_z + l_car);	glTexCoord2f(1, 1);
	glVertex3f(p_x, h2, p_z + l_car);				glTexCoord2f(0, 1);
	glEnd();

	glDisable(GL_TEXTURE_2D);

	//light
	glPushMatrix();
	glColor3f(0.7, 0.7, 0.2);
	glTranslatef(p_x + w_car + 5, 35, p_z + 10);
	glutSolidSphere(5, 48, 48);
	glPopMatrix();

	glPushMatrix();
	glColor3f(0.7, 0.7, 0.2);
	glTranslatef(p_x + w_car + 5, 35, p_z + l_car - 10);
	glutSolidSphere(5, 48, 48);
	glPopMatrix();
	
	glColor3f(1, 1, 1);
}

void DrawLights()
{
	glColor3f(0.7, 0.5, 0.3);

	glPushMatrix();
	glTranslatef(10.0, 10.0, 20.0);
	glutSolidCube(20);
	glPopMatrix();

	glPushMatrix();
	glTranslatef(10.0, 10.0, 280.0);
	glutSolidCube(20);
	glPopMatrix();

	glPushMatrix();
	glTranslatef(300.0, 10.0, 20.0);
	glutSolidCube(20);
	glPopMatrix();

	glPushMatrix();
	glTranslatef(300.0, 10.0, 280.0);
	glutSolidCube(20);
	glPopMatrix();

	glColor3f(1, 0.76, 0.678);

	glPushMatrix();
	glTranslatef(10.0, 25.0, 20.0);
	glutSolidCube(30);
	glPopMatrix();

	glPushMatrix();
	glTranslatef(10.0, 25.0, 280.0);
	glutSolidCube(30);
	glPopMatrix();

	glPushMatrix();
	glTranslatef(300.0, 25.0, 20.0);
	glutSolidCube(30);
	glPopMatrix();

	glPushMatrix();
	glTranslatef(300.0, 25.0, 280.0);
	glutSolidCube(30);
	glPopMatrix();

	glColor3f(1, 1, 1);
}

void AddLight()
{
	glPushMatrix();
	glLoadIdentity();

	GLfloat light_pos[] = { 0, 0, 0, 1.0 };
	GLfloat sp1[] = { 0, 0, -1 };
	GLfloat coff1[] = { 180 };

	glLightfv(GL_LIGHT0, GL_POSITION, light_pos);
	glLightfv(GL_LIGHT0, GL_SPOT_DIRECTION, sp1);
	glLightfv(GL_LIGHT0, GL_SPOT_CUTOFF, coff1);

	//torches
	GLfloat light_pos0[] = { 300.0, 20.0, 20.0, 1.0 };
	GLfloat light_pos1[] = { 10.0, 20.0, 20.0, 1.0 };
	GLfloat light_pos2[] = { 10.0, 20.0, 280.0, 1.0 };
	GLfloat light_pos3[] = { 300.0, 20.0, 280.0, 1.0 };
	GLfloat dif[] = { 1, 0.76, 0.9 };

	glLightfv(GL_LIGHT1, GL_POSITION, light_pos0);
	glLightfv(GL_LIGHT1, GL_DIFFUSE, dif);
	glLightfv(GL_LIGHT2, GL_POSITION, light_pos1);
	glLightfv(GL_LIGHT2, GL_DIFFUSE, dif);
	glLightfv(GL_LIGHT3, GL_POSITION, light_pos2);
	glLightfv(GL_LIGHT3, GL_DIFFUSE, dif);
	glLightfv(GL_LIGHT4, GL_POSITION, light_pos3);
	glLightfv(GL_LIGHT4, GL_DIFFUSE, dif);
	
	//car light
	GLfloat dif_p[] = { 0.7, 0.7, 0.2 };
	GLfloat sp[] = { 0.45, 0.15, -1 };
	GLfloat coff[] = { 10.0 };
	GLfloat se[] = { 50.0 };

	glPushMatrix();
	GLfloat light_pos_p[] = { p_x + w_car + 5, 35, p_z + 10, 1 };
	glLightfv(GL_LIGHT5, GL_POSITION, light_pos_p);
	glLightfv(GL_LIGHT5, GL_SPOT_DIRECTION, sp);
	glLightfv(GL_LIGHT5, GL_SPOT_CUTOFF, coff);
	glLightfv(GL_LIGHT5, GL_SPOT_EXPONENT, se);
	glLightfv(GL_LIGHT5, GL_DIFFUSE, dif_p);
	glPopMatrix();

	glPushMatrix();
	GLfloat light_pos_p1[] = { p_x + w_car + 5, 35, p_z + w_car - 10 };
	glLightfv(GL_LIGHT6, GL_POSITION, light_pos_p1);
	glLightfv(GL_LIGHT6, GL_SPOT_DIRECTION, sp);
	glLightfv(GL_LIGHT6, GL_SPOT_CUTOFF, coff);
	glLightfv(GL_LIGHT6, GL_SPOT_EXPONENT, se);
	glLightfv(GL_LIGHT6, GL_DIFFUSE, dif_p);
	glPopMatrix();

	glPopMatrix();
}

void Update(void) {
	double angle = 1;
	angle += 0.5f;

	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();
	gluLookAt(360.0f, 360.0f, 360.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
	glRotatef(rotate_x, 1.0, 0.0, 0.0);
	glRotatef(rotate_y, 0.0, 1.0, 0.0);
	glRotatef(rotate_z, 0.0, 0.0, 1.0);

	glEnable(GL_DEPTH_TEST);
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	if (flags[0])
		glEnable(GL_LIGHT1);
	if (flags[1])
		glEnable(GL_LIGHT2);
	if (flags[2])
		glEnable(GL_LIGHT3);
	if (flags[3])
		glEnable(GL_LIGHT4);
	if (flags[4])
	{
		glEnable(GL_LIGHT5);
		glEnable(GL_LIGHT6);
	}

	AddLight();
	DrawRoad();
	DrawLights();
	DrawCar();

	glDisable(GL_LIGHT0);
	glDisable(GL_LIGHT1);
	glDisable(GL_LIGHT2);
	glDisable(GL_LIGHT3);
	glDisable(GL_LIGHT4);
	glDisable(GL_LIGHT5);
	glDisable(GL_LIGHT6);
	glDisable(GL_LIGHTING);

	glDisable(GL_DEPTH_TEST);
	glFlush();
	glutSwapBuffers();
}

void Reshape(int width, int height) {
	w = width;
	h = height;
	glViewport(0, 0, w, h);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(65.0f, w / h, 1.0f, 1000.0f);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
}

void specialKeys(int key, int x, int y) {
	switch ((int)key) {
	case GLUT_KEY_DOWN: p_x -= 5; break;
	case GLUT_KEY_UP: p_x += 5; break;
	case GLUT_KEY_F1: flags[0] = !flags[0]; break;
	case GLUT_KEY_F2: flags[1] = !flags[1]; break;
	case GLUT_KEY_F3: flags[2] = !flags[2]; break;
	case GLUT_KEY_F4: flags[3] = !flags[3]; break;
	case GLUT_KEY_F5: flags[4] = !flags[4]; break;
	case GLUT_KEY_SHIFT_L: rotate_x -= 5; break;
	case GLUT_KEY_SHIFT_R: rotate_x += 5; break;
	case GLUT_KEY_CTRL_L: rotate_y -= 5; break;
	case GLUT_KEY_CTRL_R: rotate_y += 5; break;
	case GLUT_KEY_ALT_L: rotate_z -= 5; break;
	case GLUT_KEY_ALT_R: rotate_z += 5; break;
	}
	glutPostRedisplay();
}

int main(int argc, char ** argv) {
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGBA);
	glutInitWindowPosition(100, 100);
	glutInitWindowSize(800, 600);
	glutCreateWindow("Car");
	Init();
	glEnable(GL_COLOR_MATERIAL);

	glutReshapeFunc(Reshape);
	glutDisplayFunc(Update);
	glutSpecialFunc(specialKeys);

	glutMainLoop();
	return 0;
}