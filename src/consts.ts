import type { Metadata, Site, Socials } from "@types";

export const SITE: Site = {
  TITLE: "Chiihou",
  DESCRIPTION: "Blessing of the earth.",
  EMAIL: "cheily.public+site@gmail.com",
  NUM_POSTS_ON_HOMEPAGE: 5,
  NUM_PROJECTS_ON_HOMEPAGE: 3,
};

export const HOME: Metadata = {
  TITLE: "Home",
  DESCRIPTION: "Astro Micro is an accessible theme for Astro.",
};

export const BLOG: Metadata = {
  TITLE: "Blog",
  DESCRIPTION: "A collection of articles on topics I am passionate about.",
};

export const PROJECTS: Metadata = {
  TITLE: "Projects",
  DESCRIPTION:
    "A collection of my projects with links to repositories and live demos.",
};

export const GAMES: Metadata = {
  TITLE: "Games",
  DESCRIPTION:
    "A collection of games I helped develop with links to repositories and downloads.",
};

export const SOCIALS: Socials = [
  // {
  //   NAME: "X (formerly Twitter)",
  //   HREF: "https://twitter.com/boogerbuttcheeks",
  // },
  {
    NAME: "GitHub",
    HREF: "https://github.com/cheiily",
  },
  {
    NAME: "LinkedIn",
    HREF: "https://www.linkedin.com/in/grzegorz-ludziejewski/",
  },
  {
    NAME: "ItchIo",
    HREF: "https://cheily.itch.io/"
  }
];
